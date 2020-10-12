using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using TermTracker.Configuration;
using TermTracker.Enum;
using TermTracker.Utilities;
using Xamarin.Forms;

namespace TermTracker.Factory
{
    /// <summary>
    /// Factory-ish class to return the appropriate view based on the desired operation and the model type.
    /// Locates views by their DescriptionAttribute decorator value.
    /// </summary>
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

        /// <summary>
        /// Returns an entry view (Add or Edit) for the type T provided.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="op">The desired operation.</param>
        /// <param name="dConn">An initialized DataConnection object.</param>
        /// <param name="obj">(Optional) - For edit views, the object to edit.</param>
        /// <param name="parentId">(Optional) - For add views, the primary key of the parent object.</param>
        /// <returns></returns>
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

            // create an instance of the view, based on the operation
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
                 
            // cast the view as a ContentPage and return it
            return (ContentPage)view;
        
        
        }

        /// <summary>
        /// Returns a detail view for the type T provided.
        /// </summary>
        /// <typeparam name="T">The model type to load.</typeparam>
        /// <param name="dConn">An initialized DataConnection object.</param>
        /// <param name="obj">The model to load.</param>
        /// <returns></returns>
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
                        
            // create an instance of the view, cast it as a Content page, and return it
            view = Activator.CreateInstance(viewType, dConn, obj);

            return (ContentPage)view;

        }

    }
}
