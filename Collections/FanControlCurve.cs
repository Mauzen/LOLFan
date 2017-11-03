/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using LOLFan.Hardware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace LOLFan.Collections
{
    public class FanControlCurve : List<PointF>
    {
        private ISettings settings;
        //private ControlSettings control;
        private Identifier identifier;
        private float min = 0.0f;
        private float max = 100.0f;

        public FanControlCurve(Identifier identifier, ISettings settings, bool addDefault=true)
        {
            this.identifier = identifier;
            this.settings = settings;

            if (identifier != null && settings.Contains(new Identifier(Identifier, "values").ToString())) {
                LoadValuesFromSettings();
            } else
            {
                if (addDefault)
                {
                    this.Add(new PointF(0, 0));
                    this.Add(new PointF(100, 100));
                }
            }
        }
        

        public float Get(float index, bool includeZero=false)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].X > index)
                {
                    
                    if (i > 0)
                    {
                        return this[i - 1].Y + ((index - this[i - 1].X) / (this[i].X - this[i - 1].X)) * (this[i].Y - this[i - 1].Y);
                    } else
                    {
                        if (includeZero)
                        {
                            return 0 + ((index - 0) / (this[0].X - 0)) * (this[0].Y - 0);
                        }
                        else
                        {
                            return this[i].Y;
                        }
                    }
                }
                if (this[i].X < index && i == this.Count - 1) return this[i].Y;
            }
            return 100f;
        }

        // Returns the index-1 of the item that surpasses threshold
        public int GetIndex(float threshold)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].X > threshold)
                {
                    return i;
                }                
            }
            return this.Count-1;
        }

        public float GetInverse(float index, bool includeZero=false)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Y > index)
                {
                    if (i > 0)
                    {
                        return this[i - 1].X + ((index - this[i - 1].Y) / (this[i].Y - this[i - 1].Y)) * (this[i].X - this[i - 1].X);
                    }
                    else
                    {
                        if (includeZero)
                        {
                            return 0 + ((index - 0) / (this[0].Y - 0)) * (this[0].X - 0);
                        }
                        else
                        {
                            return this[i].X;
                        }
                    }
                }
                if (this[i].Y < index && i == this.Count - 1) return this[i].X;
            }
            return 100f;
        }

        public void AddOrdered(PointF p)
        {
            if (this.Count == 0) this.Add(p);
            else this.Insert(GetIndex(p.X), p);
        }


        public void SaveValuesToSettings()
        {
            if (identifier == null) return;

            using (MemoryStream m = new MemoryStream())
            {
                using (GZipStream c = new GZipStream(m, CompressionMode.Compress))
                using (BufferedStream b = new BufferedStream(c, 65536))
                using (BinaryWriter writer = new BinaryWriter(b))
                {
                    foreach (PointF p in this)
                    {
                        writer.Write(p.X);
                        writer.Write(p.Y); 
                    }
                    writer.Flush();
                }
                settings.SetValue(new Identifier(Identifier, "values").ToString(),
                  Convert.ToBase64String(m.ToArray()));
            }

            settings.SetValue(new Identifier(Identifier, "min").ToString(), min + "");
            settings.SetValue(new Identifier(Identifier, "max").ToString(), max + "");
        }

        private void LoadValuesFromSettings()
        {
            if (identifier == null) return;

            string name = new Identifier(Identifier, "values").ToString();
            string s = settings.GetValue(name, null);

            try
            {
                byte[] array = Convert.FromBase64String(s);
                using (MemoryStream m = new MemoryStream(array))
                using (GZipStream c = new GZipStream(m, CompressionMode.Decompress))
                using (BinaryReader reader = new BinaryReader(c))
                {
                    try
                    {
                        while (true)
                        {
                            PointF p = new PointF(reader.ReadSingle(), reader.ReadSingle());
                           // if (!(p.X == 100 && p.Y == 100) || (p.X == 0 && p.Y == 0))
                                this.Add(p);
                        }
                    }
                    catch (EndOfStreamException) { }
                }
            }
            catch { }
            settings.Remove(name);

            min = float.Parse(settings.GetValue(new Identifier(Identifier, "min").ToString(), "0"));
            max = float.Parse(settings.GetValue(new Identifier(Identifier, "max").ToString(), "100"));
        }


        public Identifier Identifier
        {
            get
            {
                return identifier;// new Identifier(control.Identifier, "curvePoints");
            }
            set
            {
                identifier = value;
            }
        }

        public float Min
        {
            get
            {
                return min;
            }

            set
            {
                if (value >= max) throw (new ArgumentOutOfRangeException("min"));
                min = value;
                // Recalculate values
            }
        }

        public float Max
        {
            get
            {
                return max;
            }

            set
            {
                if (value <= min) throw (new ArgumentOutOfRangeException("max"));
                max = value;
                // Recalculate values
            }
        }

        public void TransformValues(float newmin, float newmax)
        {
            // Scale curve points to different min/max x range
            for (int i = 0; i < this.Count; i++)
            {
                float norm = (this[i].X - min) / (max - min);
                this[i] = new PointF(newmin + norm * (newmax - newmin), this[i].Y);
            }
            min = newmin;
            max = newmax;
        }
    }
}
