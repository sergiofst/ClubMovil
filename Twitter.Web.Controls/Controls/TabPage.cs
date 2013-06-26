﻿// ${FileName}

// Copyright (C) 2013 Pedro Fernandes

// This program is free software; you can redistribute it and/or modify it under the terms of the GNU 
// General Public License as published by the Free Software Foundation; either version 2 of the 
// License, or (at your option) any later version.

// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without 
// even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See 
// the GNU General Public License for more details. You should have received a copy of the GNU 
// General Public License along with this program; if not, write to the Free Software Foundation, Inc., 59 
// Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.ComponentModel;
using System.Web.UI;

namespace Twitter.Web.Controls
{
    /// <summary>
    /// The individual TabPage class that holds the intermediary Tab page values
    /// </summary>
    [ToolboxData("<{0}:TabPage runat=server></{0}:TabPage>")]
    [ToolboxItem(false)]
    public class TabPage : Control, INamingContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabPage" /> class.
        /// </summary>
        public TabPage()
        {
            this.Enabled = true;
            this.Title = this.ID;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [NotifyParentProperty(true)]
        [Browsable(true)]
        [Localizable(true)]
        [DefaultValue("")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TabPage" /> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        [NotifyParentProperty(true)]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool Enabled
        {
            get;
            set;
        }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter" /> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the server control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            string strCssClass = "";

            if (this.Enabled == false)
            {
                strCssClass = " disabled";
                strCssClass = strCssClass.Trim();
            }

            //strCssClass += (i == this.ActiveTabPage ? " active" : "");

            if (!String.IsNullOrEmpty(strCssClass)) writer.AddAttribute(HtmlTextWriterAttribute.Class, strCssClass);
            writer.RenderBeginTag(HtmlTextWriterTag.Li);

            writer.AddAttribute(HtmlTextWriterAttribute.Href, "#" + this.ClientID);
            writer.AddAttribute("data-toggle", "tab");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write(this.Title);
            writer.RenderEndTag();

            writer.RenderEndTag();
           
            base.Render(writer);
        }
    }
}