﻿using System;
using System.Web.UI;

namespace assignment
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Optional initialization
            }
        }
    }
}