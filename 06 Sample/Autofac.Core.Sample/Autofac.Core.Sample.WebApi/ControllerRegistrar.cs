﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofac.Core.Sample.WebApi
{
    public class ControllerRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// 
        /// </summary>
        public int Order
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="listType"></param>
        public void Register(ContainerBuilder builder, List<Type> listType)
        {
            //注册Controller,实现属性注入
            var IControllerType = typeof(ControllerBase);
            var arrControllerType = listType.Where(t => IControllerType.IsAssignableFrom(t) && t != IControllerType).ToArray();
            builder.RegisterTypes(arrControllerType).PropertiesAutowired();
        }
    }
}
