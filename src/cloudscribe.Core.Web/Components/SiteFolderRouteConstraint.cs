﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2015-06-19
// Last Modified:			2016-05-18
// 

using cloudscribe.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace cloudscribe.Core.Web.Components
{
    /// <summary>
    /// used when creating routes for folder based multi tenant scenarios
    /// constrains the route based on the first url segment which identifies
    /// the site
    /// </summary>
    public class SiteFolderRouteConstraint : IRouteConstraint
    {
        public SiteFolderRouteConstraint()
        {
            
        }

        public bool Match(
            HttpContext httpContext, 
            IRouter route, 
            string routeKey, 
            RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            string requestFolder = httpContext.Request.Path.StartingSegment();

            var tenant = httpContext.GetTenant<SiteSettings>();

            if (tenant != null)
            {
                if (tenant.SiteFolderName == requestFolder) { return true; }

            }

            return false;
        }
        
        
    }
}
