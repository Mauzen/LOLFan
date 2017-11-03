/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2017 Michael Möller <mmoeller@openhardwaremonitor.org>
    Copyright (C) 2017 Michel Soll <msoll@web.de>   

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace LOLFan.GUI {
  public partial class AboutBox : Form {
    public AboutBox() {
      InitializeComponent();
      this.Font = SystemFonts.MessageBoxFont;
      this.label6.Text = "Version " + 
        System.Windows.Forms.Application.ProductVersion;

            linkLabel1.Links.Remove(linkLabel1.Links[0]);
            linkLabel1.Links.Add(0, linkLabel1.Text.Length,
              "License.html");

            linkLabel2.Links.Remove(linkLabel2.Links[0]);
            linkLabel2.Links.Add(0, linkLabel2.Text.Length,
              "http://mauzen.org/lolfan");


            projectLinkLabel.Links.Remove(projectLinkLabel.Links[0]);
      projectLinkLabel.Links.Add(0, projectLinkLabel.Text.Length,
        "http://openhardwaremonitor.org");

      licenseLinkLabel.Links.Remove(licenseLinkLabel.Links[0]);
      licenseLinkLabel.Links.Add(0, licenseLinkLabel.Text.Length,
        "License.html");
    }

    private void linkLabel_LinkClicked(object sender, 
      LinkLabelLinkClickedEventArgs e) {
      try {
        Process.Start(new ProcessStartInfo(e.Link.LinkData.ToString()));
      } catch { }
    }

  }
}
