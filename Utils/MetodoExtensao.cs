using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaronteCore.Utils
{
    public static class MetodoExtensao
    {

        public static T BuscarValor<T>(IDataReader reader, string nomeColuna)
        {
            T valor = default(T);
            try
            {
                int index = reader.GetOrdinal(nomeColuna);
                if (!reader.IsDBNull(index))
                    return (T)reader[index];
            }
            catch (IndexOutOfRangeException) { }

            return valor;
        }


        public static TEnum Parse<TEnum>(this String value) where TEnum : struct
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }

    }
}
