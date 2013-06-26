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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Twitter.Web.Controls
{
    public enum Position
    {
        None = 0,
        Top = 1,
        Bottom = 2
    }

    [ToolboxData("<{0}:NavBar runat=server></{0}:NavBar>")]
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.BulletedList))]
    [ParseChildren(true, "Content")]
    [PersistChildren(false)]
    public class NavBar : WebControl, INamingContainer
    {
        #region CssClass method

        string sCssClass = "";

        /// <summary>
        /// Adds the CSS class.
        /// </summary>
        /// <param name="cssClass">The CSS class.</param>
        private void AddCssClass(string cssClass)
        {
            if (String.IsNullOrEmpty(this.sCssClass))
            {
                this.sCssClass = cssClass;
            }
            else
            {
                this.sCssClass += " " + cssClass;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="NavBar" /> class.
        /// </summary>
        public NavBar()
        {
            this.Position = Position.None;
            this.Inverted = true;
            this.Fixed = false;
        }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateContainer(typeof(NavBar))]
        [TemplateInstance(TemplateInstance.Single)]
        public virtual ITemplate Content
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        [Category("Appearance")]
        [DefaultValue(Position.None)]
        public Position Position
        {
            get { return (Position)ViewState["Position"]; }
            set { ViewState["Position"] = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NavBar" /> is inverted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if inverted; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool Inverted
        {
            get { return (bool)ViewState["Inverted"]; }
            set { ViewState["Inverted"] = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NavBar" /> is fixed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fixed; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool Fixed
        {
            get { return (bool)ViewState["Fixed"]; }
            set { ViewState["Fixed"] = value; }
        }


        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [Category("Appearance")]
        [DefaultValue("")]
        public string Title
        {
            get { return (string)ViewState["Title"]; }
            set { ViewState["Title"] = value; }
        }

        /// <summary>
        /// Renders the HTML opening tag of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter" /> that represents the output stream to render HTML content on the client.</param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
        }

        /// <summary>
        /// Renders the HTML closing tag of the control into the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter" /> that represents the output stream to render HTML content on the client.</param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.RenderEndTag();
        }

          /// <summary>
        /// Renders the control to the specified HTML writer.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            this.AddCssClass(this.CssClass);
            this.AddCssClass("navbar");

            if (this.Inverted)
            {
                this.AddCssClass("navbar-inverse");
            }            

            switch (this.Position)
            {
                case Web.Controls.Position.Top:
                    this.AddCssClass("navbar-" + (Fixed ? "fixed" : "static") + "-top");
                    break;

                case Web.Controls.Position.Bottom:
                    this.AddCssClass("navbar-" + (Fixed ? "fixed" : "static") + "-bottom");
                    break;

                default:
                    break;
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
            writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
            if (!String.IsNullOrEmpty(this.sCssClass)) writer.AddAttribute(HtmlTextWriterAttribute.Class, this.sCssClass);

            base.Render(writer);
        }

        /// <summary>
        /// Renders the contents.
        /// </summary>
        /// <param name="output">The output.</param>
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Class, "navbar-inner");
            output.RenderBeginTag(HtmlTextWriterTag.Div);
           
            this.RenderTitle(output);
            this.RenderChildren(output);

            output.RenderEndTag(); // Close Div   
        }

        /// <summary>
        /// Renders the title.
        /// </summary>
        /// <param name="output">The output.</param>
        private void RenderTitle(HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Class, "brand");
            output.AddAttribute(HtmlTextWriterAttribute.Href, "#");
            output.RenderBeginTag(HtmlTextWriterTag.A);            
            output.Write(this.Title);
            output.RenderEndTag();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);

            // Initialize all child controls.
            this.CreateChildControls();
            this.ChildControlsCreated = true;
        }

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            var container = new Control();
            this.Content.InstantiateIn(container);

            this.Controls.Clear();
            this.Controls.Add(container);
        }
    }
}
