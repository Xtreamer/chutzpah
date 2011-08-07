﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Chutzpah
{
    public class ChutzpahContainer
    {
        public static IContainer Current
        {
            get { return container; }
        }

        private static IContainer container = CreateContainer();

        private static IContainer CreateContainer()
        {
            var container = new Container();
            container.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.AddAllTypesOf<IReferencedFileProcessor>();
                });
            });


            return container;
        }
    }
}