/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 17/4/2026
 * Hora: 11:08 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TallerCsharp001
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("===Taller 001===");
			
			//  1. El dato del usuario
			string registroUsuario = "     ID_777;    Zeze Crespo;   EVALUACION;   95";
			
			Console.WriteLine(registroUsuario);
			
			string registroLimpio = registroUsuario.Trim();
			
			Console.WriteLine(registroLimpio);
			
			string[] partes = registroLimpio.Split(';');
			string id = partes[0].Trim();
			string nombre = partes[1].Trim();
			string tarea = partes[2].Trim();
			string nota = partes[3].Trim();
			
			Console.WriteLine(string.Format("El ID es: {0} del usuario {1} y la nota es: {2} en su {3}" , id, nombre, nota, tarea));
			
			
			
			
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}