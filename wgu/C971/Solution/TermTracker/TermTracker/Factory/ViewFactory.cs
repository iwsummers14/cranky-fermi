using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using TermTracker.Configuration;
using TermTracker.Enum;
using TermTracker.Interfaces;
using TermTracker.Models;
using TermTracker.Utilities;
using TermTracker.Views;
using Xamarin.Forms;

namespace TermTracker.Factory
{
    public class ViewFactory
    {
       
       private List<Type> ViewTypes { get; set; }

        public ViewFactory()
        {
            // get types from Views namespace
            ViewTypes = Assembly.GetAssembly(typeof(Startup)).GetTypes().Where(
                vtype => vtype.Namespace == "TermTracker.Views"  
            ).ToList();
                        
        }

       public ContentPage GetEntryView<T>(UserOperation op, SQLiteAsyncConnection dConn, [Optional] T obj, [Optional] int parentId) 
        {
            object view = null;
            Type viewType = null;
            Type objType = typeof(T);
            string description = EnumUtilities.GetDescription(ViewType.Entry) + objType.Name; 

            // get the first type that has the proper Description attribute value
            foreach (Type eType in ViewTypes)
            {
                var attrs = (DescriptionAttribute[])eType.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                {
                    if (attrs.ToList().First().Description == description)
                    {
                        viewType = eType;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }


            switch (op)
            {
                case UserOperation.Add:
                    view = Activator.CreateInstance(viewType, dConn, parentId);
                    break;

                case UserOperation.Edit:
                    view = Activator.CreateInstance(viewType, dConn, obj);
                    break;

                default:
                    break;
            }
                 
            return (ContentPage)view;
        
        
        }

        public ContentPage GetDetailView<T>(SQLiteAsyncConnection dConn, T obj)
        {
            object view = null;
            Type viewType = null;
            Type objType = typeof(T);
            string description = EnumUtilities.GetDescription(ViewType.Detail) + objType.Name;

            // get the first type that has the proper Description attribute value
            foreach (Type dType in ViewTypes)
            {
                var attrs = (DescriptionAttribute[])dType.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                {
                    if (attrs.ToList().First().Description == description)
                    {
                        viewType = dType;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
                        
            view = Activator.CreateInstance(viewType, dConn, obj);

            return (ContentPage)view;


        }

    }
}
