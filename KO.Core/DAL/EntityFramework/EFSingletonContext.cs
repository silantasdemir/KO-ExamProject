using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.Core.DAL.EntityFramework
{
    public class EFSingletonContext<TContext> where TContext : DbContext, new()
    {
        private static TContext _instance;
        public static TContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TContext();
                }
                return _instance;
            }
        }
    }
}
