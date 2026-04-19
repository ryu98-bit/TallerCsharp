/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 17/4/2026
 * Hora: 11:08 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace TallerCsharp001
{
	class Program
	{
		public static void Main(string[] args)
		{
            Console.WriteLine("===Taller 01===");
            Console.WriteLine("\n");

            //1. El dato del usuario

            string registroUsuario = "    ID_333   ; Zeze Crespo ;  EVALUACION   ;   93";


            string registroLimpio = registroUsuario.Trim().Trim();


            Console.WriteLine(registroLimpio);

            Console.WriteLine("\n");

            string[] partes = registroLimpio.Split(';');
            string id = partes[0].Trim();
            string nombre = partes[1].Trim();
            string tarea = partes[2].Trim();
            string nota = partes[3].Trim();

            Console.WriteLine("=================================");
            Console.WriteLine(string.Format(" El id es: {0} \n Usuario: {1} \n La nota {2} \n Evaluacion: {3}", id, nombre, nota, tarea));
            Console.WriteLine("=================================");

            Console.WriteLine("\n");

            //2. flujo de archivos

            string rutaraiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIUJO");

            if (!Directory.Exists(rutaraiz))
            {
                Directory.CreateDirectory(rutaraiz);

                Console.WriteLine("Directorio Creado con exito");
            }

            string archivotexto = Path.Combine(rutaraiz, "notas.txt");



            Console.WriteLine("\n");

            Console.WriteLine(archivotexto);

            Console.WriteLine("\n");

            using (StreamWriter sw = new StreamWriter(archivotexto, true))
            {
                sw.WriteLine(string.Format("ID : {0} Nota {1} Fecha: {2}", id, nota, DateTime.Now.ToString("yyyy-MM-dd-HH:mm")));
            }

            // ===== Desafio 1: El Validador de Seguridad =====

            Console.WriteLine("\n");
            Console.WriteLine("=====Desafio 1=====");

            string entradaSeguridad = "Fabian;Clave123";
            string[] datosSeguridad = entradaSeguridad.Split(';');
            string clave = datosSeguridad[1];

            if (clave.Contains("123"))
            {
                using (StreamWriter swSeg = new StreamWriter(Path.Combine(rutaraiz, "seguridad.txt"), true))
                {
                    swSeg.WriteLine("Alerta: Clave Debíl detectada para el usuario:" + datosSeguridad[0]);
                }
                Console.WriteLine("¡Aviso de seguridad guardado!");
            }

            // ===== Desafio 2: El Clonador de Imagenes (Filestream) =====

            Console.WriteLine("\n");
            Console.WriteLine("=====Desafio 2=====");

            string rutaOriginal = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "perfil.jpg");
            string rutaCopia = Path.Combine(rutaraiz, "respaldo.jpg");

            if (File.Exists(rutaOriginal))
            {
                using (FileStream Origen = new FileStream(rutaOriginal, FileMode.Open))
                using (FileStream destino = new FileStream(rutaCopia, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    int bytesLeidos;

                    while ((bytesLeidos = Origen.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destino.Write(buffer, 0, bytesLeidos);
                    }
                }
                Console.WriteLine("Imagen clonada con éxito en la carpeta" + rutaraiz);
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("No se encontró 'perfil.jpg' en la carpeta Debug.");
                Console.WriteLine("\n");
            }

            // ===== Desafio 3: El Buscador de Archivos Pesados =====

            Console.WriteLine("\n");
            Console.WriteLine("=====Desafio 3=====");

            string[] todosLosArchivos = Directory.GetFiles(rutaraiz);

            foreach (string ruta in todosLosArchivos)
            {
                FileInfo info = new FileInfo(ruta);

                if (info.Length > 5120)
                {
                    string nombreArchivo = info.Name;
                    long tamaño = info.Length;
                    info.Delete();

                    Console.WriteLine("Archivo borrado por exceder los 5KB", nombreArchivo, tamaño);
                }
            }
            Console.WriteLine("Proceso de borrado completado.");
            Console.WriteLine("\n");

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
	}
}