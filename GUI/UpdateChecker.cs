/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LOLFan.GUI
{
    class UpdateChecker
    {
        private Version version;

        public UpdateChecker()
        {
            this.version = typeof(UpdateChecker).Assembly.GetName().Version;
            
        }

        public void Check(bool manual)
        {
            try
            {

                WebClient client = new WebClient();
                String data = client.DownloadString("http://mauzen.org/lolfan/checkversion.php");
                String[] info = data.Split(' ');

                Version current = new Version(info[0]);

                if (version < current)
                {
                    DialogResult result;

                    result = MessageBox.Show("There is a new version available\n"
                            + "Your version: " + version.ToString() + "\n"
                            + "New version: " + current.ToString() + " (" + info[1] + ")\n"
                            + "Changelogs are available on the website\n\n"
                            + "Do you want to visit the website to download the update?", "New version available", MessageBoxButtons.YesNo);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("http://www.mauzen.org/lolfan/downloads.php");
                    }
                }
                else if (manual)
                {
                    MessageBox.Show("Your version is up-to-date.", "No update available", MessageBoxButtons.OK);
                }
            } catch (WebException)
            {

            }
        }
    }
}
