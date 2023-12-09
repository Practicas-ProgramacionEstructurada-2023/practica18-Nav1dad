using System;
using System.IO;

namespace MyApp// Note: actual namespace depends on the project name.
{
    internal class Program
    {
         static void Main(string[] args)
        {
            string filePath = "datos.bin";

            // ESCRIBIR DATOS ALEATORIOS EN EL ARCHIVO
            EscribirDatosAleatorios(filePath);

            // LEER DATOS ALEATORIOS DEL ARCHIVO
            LeerDatos(filePath);

            Console.ReadLine();
        }

        static void EscribirDatosAleatorios(string filePath)
        {
            Random random = new Random();

            // ABRIR EL ARCHIVO EN MODO DE ESTRUCTURA
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Read))
            using (BinaryWriter writer = new BinaryWriter(fileStream))
            {
                // ESCRIBIR DATOS ALEATORIOS EN UBICACIONES ESPECIFICAS
                EscribeDatosEnPosicion(writer, 0, GenerarNumeroAleatorio(random));
                EscribeDatosEnPosicion(writer, 1, GenerarNumeroAleatorio(random));
                EscribeDatosEnPosicion(writer, 2, GenerarNumeroAleatorio(random));

                Console.WriteLine("\nDatos escritos en el archivo.");
            }
        }  

        static int GenerarNumeroAleatorio(Random random)
        {
            // GENERAR UN NUMERO ALEATORIO ENTRE 0 Y 255 (UN BYTE)
            return random.Next(256);
        } 

        static void EscribeDatosEnPosicion(BinaryWriter writer, int posicion, int dato)
        {
            // CALCULAR LA POSICION EN BYTES
            long bytePosicion = posicion * sizeof(int);

            // MOVER EL PUNTERO DE ESCRITURA A LA POSICION DESEADA
            writer.Seek((int)bytePosicion, SeekOrigin.Begin);

            // ESCRIBIR EL DATO EN LA POSICION ESPECIFICA
            writer.Write(dato);

        }

        static void LeerDatos(string filePath)
        {
            // ABRIR EL ARCHIVO EN MODO DE LECTURA
            using(FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using(BinaryReader reader = new BinaryReader(fileStream))
            {
                // LEER DATOS DE UBICACIONES ESPECIFICAS
                Console.WriteLine("Dato en posicion 0: " + LeeDatosEnPosicion(reader, 0));
                Console.WriteLine("Dato en posicion 1: " + LeeDatosEnPosicion(reader, 0));
                Console.WriteLine("Dato en posicion 2: " + LeeDatosEnPosicion(reader, 0));
            }
        }

        static int LeeDatosEnPosicion(BinaryReader reader, int posicion)
        {
            // CALCULAR LA POSICION EN BYTES
            long bytePosicion = posicion * sizeof(int);
            
            // MOVER EL PUNTERO DE LECTURA A LA POSICION DESEADA
            reader.BaseStream.Seek(bytePosicion, SeekOrigin.Begin);

            // LEER EL DATO EN LA POSICION ESPECIFICA
            return reader.ReadInt32();
        }

    }
}
// NOMBRE: PEDRO ANTONIO ALVAREZ HERNADEZ
// CODIGO: U20230697