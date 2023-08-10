
using System.Data;
using System.Reflection;

namespace CrudTest.DataAccess
{
    public static class DataStructuresConverter
    {
        #region Public Properties
        public static char ComplexColumnsSeparatorChar = '.'; //if you want to change the complex columns separator
        #endregion

        #region Static Extension Methods
        public static List<T> ToListOfType<T>(this DataTable table) where T : class, new()
        {
            return ConvertDataTableToList<T>(table);
        }
        public static T ToType<T>(this DataRow row) where T : class, new()
        {
            return ConvertDataRowToType<T>(row);
        }
        #endregion

        #region Static Methods
        public static List<T> ConvertDataTableToList<T>(DataTable table) where T : class, new()
        {
            //http://codereview.stackexchange.com/questions/30714/faster-way-to-convert-datatable-to-list-of-class
            //http://www.c-sharpcorner.com/UploadFile/ee01e6/different-way-to-convert-datatable-to-list/

            List<T> list = new List<T>();
            //  IEnumerable<T> list1 = table.Rows.Cast<T>();
            //  list = list1.ToList();
            T obj = new T();
            IEnumerable<PropertyInfo> props = GetProps(obj, table);
            string[] ComplexColumns = GetComplexColumnsNames(table);
            foreach (DataRow row in table.Rows)
                list.Add(AssignValuesToTheObject(obj, row, props, ComplexColumns));
            return list;
        }
        public static T ConvertDataRowToType<T>(DataRow row) where T : class, new()
        {
            //T obj = Activator.CreateInstance<T>();
            T obj = new T();
            return AssignValuesToTheObject(obj, row, GetProps(obj, row.Table), GetComplexColumnsNames(row.Table));
        }
        #endregion

        #region Private Helper Methods
        private static IEnumerable<PropertyInfo> GetProps<T>(T obj, DataTable table)
        {
            return obj.GetType().GetProperties().Where(p => p.CanWrite && table.Columns.Contains(p.Name));
        }
        private static string[] GetComplexColumnsNames(DataTable table)
        {
            return table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).Where(x => x.Contains(ComplexColumnsSeparatorChar)).ToArray();
        }
        private static T AssignValuesToTheObject<T>(T obj, DataRow row, IEnumerable<PropertyInfo> props, string[] complexColumnsNames = null) where T : class, new()
        {
            obj = new T();
            foreach (var prop in props)
                AssignValueToProperty(obj, prop, row[prop.Name]);
            AssignValueToComplexProperty(obj, row, props, complexColumnsNames);
            return obj;
        }
        private static PropertyInfo AssignValueToProperty<T>(T obj, PropertyInfo prop, object value)
        {
            if (value == DBNull.Value)
            {
                switch (prop.PropertyType.Name)
                {
                    case "String": prop.SetValue(obj, ""); break;
                    case "Nullable`1": prop.SetValue(obj, null); break;
                    case "Boolean": prop.SetValue(obj, null); break;
                    case "DateTime": prop.SetValue(obj, null); break;
                    default: prop.SetValue(obj, value); break;
                }
            }
            else
            {
                if (prop.PropertyType.Name == "DateTime" && (value.ToString()[1].ToString() == "" || value.ToString()[2].ToString() == ":")) // Sql Time
                    prop.SetValue(obj, DateTime.Parse(value.ToString()));
                else
                    prop.SetValue(obj, value);
                //prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType));
            }
            return prop;
        }
        private static T AssignValueToComplexProperty<T>(T obj, DataRow row, IEnumerable<PropertyInfo> props, string[] complexColumnsNames = null)
        {
            if (complexColumnsNames != null)
            {
                for (int i = 0; i < complexColumnsNames.Length; i++)
                {
                    string[] complexPropParts = complexColumnsNames[i].Split(new char[] { ComplexColumnsSeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
                    PropertyInfo currentProp = null;
                    object previousPropInstance = 1;
                    for (int z = 0; z < complexPropParts.Length; z++)
                    {
                        if (z == 0) // First Level
                        {
                            currentProp = obj.GetType().GetProperty(complexPropParts[z]);
                            if (currentProp.GetValue(obj) == null)
                                obj.GetType().GetProperty(complexPropParts[z]).SetValue(obj, Activator.CreateInstance(currentProp.PropertyType));
                        }
                        else if (z < complexPropParts.Length - 1) // Intermidate Level(s)
                        {
                            previousPropInstance = currentProp.GetMethod.Invoke(z == 1 ? (object)obj : (object)previousPropInstance, null);
                            currentProp = currentProp.PropertyType.GetProperty(complexPropParts[z]);
                            if (currentProp.GetValue(previousPropInstance) == null)
                                previousPropInstance.GetType().GetProperty(complexPropParts[z]).SetValue(previousPropInstance, Activator.CreateInstance(currentProp.PropertyType));
                        }
                        else // Last Level
                        {
                            AssignValueToProperty(currentProp.GetMethod.Invoke(z == 1 ? (object)obj : (object)previousPropInstance, null), currentProp.PropertyType.GetProperty(complexPropParts[z]), row[complexColumnsNames[i]]);
                        }
                    }
                }
            }
            return obj;
        }
        #endregion
    }
}