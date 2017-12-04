/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2012 Michael Möller <mmoeller@openhardwaremonitor.org>
    Copyright (C) 2017 Michel Soll <msoll@web.de>   

*/

using System;
using System.Collections.Generic;
using System.Drawing;
using LOLFan.Hardware;

namespace LOLFan.GUI {
  public class HardwareNode : Node {

    private PersistentSettings settings;
    private UnitManager unitManager;
    private IHardware hardware;

    private List<TypeNode> typeNodes = new List<TypeNode>();

    public HardwareNode(IHardware hardware, PersistentSettings settings, 
      UnitManager unitManager) : base(hardware.Identifier, settings) 
    {
      this.settings = settings;
      this.unitManager = unitManager;
      this.hardware = hardware;
      this.Image = HardwareTypeImage.Instance.GetImage(hardware.HardwareType);
      

            foreach (SensorType sensorType in Enum.GetValues(typeof(SensorType)))
        typeNodes.Add(new TypeNode(sensorType, new Identifier(hardware.Identifier, sensorType.ToString()), settings));

      foreach (ISensor sensor in hardware.Sensors)
        SensorAdded(sensor);

            bool hidden = settings.GetValue(new Identifier(hardware.Identifier,
             "hidden").ToString(), false);
            base.IsVisible = !hidden;

            hardware.SensorAdded +=new SensorEventHandler(SensorAdded);
      hardware.SensorRemoved += new SensorEventHandler(SensorRemoved);
    }

    public override string Text {
      get { return hardware.Name; }
      set { hardware.Name = value; }
    }


        public override bool IsVisible
        {
            get { return base.IsVisible; }
            set
            {
                base.IsVisible = value;
                settings.SetValue(new Identifier(hardware.Identifier,
                  "hidden").ToString(), !value);
            }
        }

        public IHardware Hardware {
      get { return hardware; }
    }

    private void UpdateNode(TypeNode node) {  
      if (node.Nodes.Count > 0) {
        if (!Nodes.Contains(node)) {
          int i = 0;
          while (i < Nodes.Count &&
            ((TypeNode)Nodes[i]).SensorType < node.SensorType)
            i++;
          Nodes.Insert(i, node);  
        }
      } else {
        if (Nodes.Contains(node))
          Nodes.Remove(node);
      }
    }

    private void SensorRemoved(ISensor sensor) {
      foreach (TypeNode typeNode in typeNodes)
        if (typeNode.SensorType == sensor.SensorType) { 
          SensorNode sensorNode = null;
          foreach (Node node in typeNode.Nodes) {
            SensorNode n = node as SensorNode;
            if (n != null && n.Sensor == sensor)
              sensorNode = n;
          }
          if (sensorNode != null) {
            sensorNode.PlotSelectionChanged -= SensorPlotSelectionChanged;
            sensorNode.OverviewSelectionChanged -= SensorOverviewSelectionChanged;
            typeNode.Nodes.Remove(sensorNode);
            UpdateNode(typeNode);
          }
        }
      if (PlotSelectionChanged != null)
        PlotSelectionChanged(this, null);
      if (OverviewSelectionChanged != null)
          OverviewSelectionChanged(this, null);
        }

    private void InsertSorted(Node node, ISensor sensor) {
      int i = 0;
      while (i < node.Nodes.Count &&
        ((SensorNode)node.Nodes[i]).Sensor.Index < sensor.Index)
        i++;
      SensorNode sensorNode = new SensorNode(sensor, settings, unitManager);
      sensorNode.PlotSelectionChanged += SensorPlotSelectionChanged;
      sensorNode.OverviewSelectionChanged += SensorOverviewSelectionChanged;
      node.Nodes.Insert(i, sensorNode);
    }

    private void SensorPlotSelectionChanged(object sender, EventArgs e) {
      if (PlotSelectionChanged != null)
        PlotSelectionChanged(this, null);
    }
    private void SensorOverviewSelectionChanged(object sender, EventArgs e)
    {
        if (OverviewSelectionChanged != null)
            OverviewSelectionChanged(this, null);
    }

        private void SensorAdded(ISensor sensor) {
      foreach (TypeNode typeNode in typeNodes)
        if (typeNode.SensorType == sensor.SensorType) {
          InsertSorted(typeNode, sensor);
          UpdateNode(typeNode);          
        }
      if (PlotSelectionChanged != null)
        PlotSelectionChanged(this, null);
      if (OverviewSelectionChanged != null)
        OverviewSelectionChanged(this, null);
        }

    public event EventHandler PlotSelectionChanged;
    public event EventHandler OverviewSelectionChanged;
  }
}
