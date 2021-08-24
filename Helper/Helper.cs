namespace BackEnd.Helper
{
    public static class Helpers
    {
        public static bool ContainValue<T>(this T model, string value) where T : class
        {
            if (model == null || value == null)
                return false;

            value = value.ToLower();

            // Definindo o estado do retorno padrão
            var result = false;
            // Pegando o tipo
            var _type_ = model.GetType();

            // Percorrendo as propriedades do modelo
            foreach (var p in _type_.GetProperties())
            {
                var v = p?.GetValue(model)?.ToString();
                // Checking value
                var res = v?.ToLower().Contains(value);

                // Checking if is valid
                if (res == null)
                    continue;

                // Checking result
                if ((bool)res)
                {
                    // Modificando a variavel de retorno
                    result = true;
                    // Quebrando do ciclo
                    break;
                }
            }

            // Retornado o valor avalido
            return result;
        }

        public static string StartString(this string str,int start,int end)
        {
            string newStr="";
            var subStr=str.Substring(start);
            subStr=subStr.TrimEnd();
            for(var i=0;i<end;i++)
            {
               //var space=subStr[i].ToString();
               if(subStr.Length>i)
               newStr+=subStr[i];  
            }  
            return newStr;   
        }
        
    }
}