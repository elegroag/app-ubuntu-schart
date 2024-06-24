// See https://aka.ms/new-console-template for more information
using System;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace BackFacture
{

    /**
    * Program class
    * @command dotnet run BackFacture.MiClaseEjemplo MiMetodoJson "{\"Nombre\":\"Juan\",\"Edad\":30}" 450 development true
    */
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Uso: MiAplicacionConsola <clase> <metodo> <dataJson> <enviroment>");
                return;
            }

            string clase = args[0];
            string metodo = args[1];
            string dataJson = args[2];
            Config.User = args[3];
            Config.Enviroment = args[4];
            Config.Verbose = (args.Length == 6) && (args[5] == "true");

            if (Config.Verbose)
            {
                Console.WriteLine($"Clase: {clase}");
                Console.WriteLine($"Metodo: {metodo}");
                Console.WriteLine($"Data JSON: {dataJson}");
                Console.WriteLine($"Entorno: {Config.Enviroment}");
                Console.WriteLine($"User: {Config.User}");
            }

            // Deserializar el JSON en un objeto
            // var data = JsonSerializer.Deserialize<dynamic>(dataJson);
            var data = JObject.Parse(dataJson);

            // Aquí puedes llamar a la clase y método dinámicamente usando Reflection
            CallMethod(clase, metodo, data);
        }

        static void CallMethod(string className, string methodName, JObject data)
        {
            try
            {
                // Cargar el tipo de la clase
                Type type = Type.GetType(className);
                if (type == null)
                {
                    Console.WriteLine($"Clase '{className}' no encontrada.");
                    return;
                }

                // Crear una instancia de la clase
                object classInstance = Activator.CreateInstance(type);
                if (classInstance == null)
                {
                    Console.WriteLine($"No se pudo crear una instancia de la clase '{className}'.");
                    return;
                }

                // Encontrar el método
                var method = type.GetMethod(methodName);
                if (method == null)
                {
                    Console.WriteLine($"Método '{methodName}' no encontrado en la clase '{className}'.");
                    return;
                }

                // Invocar el método
                var response = method.Invoke(classInstance, new object[] { data }) as Response;
                if (response != null)
                {
                    Console.WriteLine("\r"+response.ToJson());
                }
                else
                {
                    Console.WriteLine("El método no retornó un objeto Response.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al invocar el método: {ex.Message}");
            }
        }

        static void CallMethod2(string className, string methodName, dynamic data)
        {
            try
            {
                // Cargar el tipo de la clase
                Type type = Type.GetType(className);
                if (type == null)
                {
                    Console.WriteLine($"Clase '{className}' no encontrada.");
                    return;
                }

                // Crear una instancia de la clase
                object classInstance = Activator.CreateInstance(type);
                if (classInstance == null)
                {
                    Console.WriteLine($"No se pudo crear una instancia de la clase '{className}'.");
                    return;
                }

                // Encontrar el método
                var method = type.GetMethod(methodName);
                if (method == null)
                {
                    Console.WriteLine($"Método '{methodName}' no encontrado en la clase '{className}'.");
                    return;
                }

                // Invocar el método
                method.Invoke(classInstance, new object[] { data });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al invocar el método: {ex.Message}");
            }
        }
    }
}

