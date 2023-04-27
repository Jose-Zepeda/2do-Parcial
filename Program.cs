using System;

//ASIGNAR A TODAS LAS POSICIONES EL VALOR 0


int fila = 0 , columna = 0;
int filas, columnas, opcion, contador=0, intentos=0;


void Parcial()
{
 
try
{
    //INGRESAR LA DIFICULTAD A LA QUE SE DESEA JUGAR

    Console.Write("-Seleccione la dificultad a la que desea jugar:\n1) Facil(5x5)\n2) Intermedio(10x10)\n3) Dificl(15x15)\n>");
    opcion = int.Parse(Console.ReadLine());

    //ASIGNAR EL TAMAÑO DEL ARREGLO DEPENDIENDO DE LO QUE ESCRIBIO EL USUARIO POR MEDIO DE UN SWITCH

        switch (opcion)
        {
            case 1:
                filas = 5;
                columnas = 5;
                break;
            case 2:
                filas = 10;
                columnas = 10;
                break;
            case 3:
                filas = 15;
                columnas = 15;
                break;
            default:
                Console.Clear();
                Console.WriteLine(">Error: ingrese un numero entre 1 y 3.\n");
                Parcial();
                
                return;
        }
    
//DECLARACION DEL ARREGLO BIDIMENSIONAL

int[,] tablero = new int [filas,columnas];
 
//ASIGNAR A TODAS LA POSICIONES EL VALOR 0

void paso1()
{
    for (int i=0;i<tablero.GetLength(0);i++)
    {
        for (int c=0;c<tablero.GetLength(1);c++)
        {
            tablero[i, c] = 0;

        }
    }
}

//ASIGNAR POSICIONES ALEATORIAMENTE A 5 BARCOS

void paso2()
{
    Random ran = new Random();
    int fil = 0, col = 0;
do
{


    for (int i = 0; i < 5; i++)
    {
        fil = ran.Next(0,filas);
        col = ran.Next(0,columnas);

        tablero[fil,col] = 1;
    }
} while(tablero[fil,col] == 0);

}

//ASIGNAR UN CARACTER A UNA POSICION SEGUN EL VALOR QUE ESTE ASIGNADO EN ESTA, LUEGO IMPRIMIR EL TABLERO

void paso3()
{
    string caracterA = "";
    for (int i = 0; i < tablero.GetLength(0); i++)
    {
        for (int c = 0; c < tablero.GetLength(1); c++)
        {
            switch(tablero[i,c])
            {
                case 0:
                    caracterA = "-";
                    break;
                case 1:
                    caracterA = "-";
                    break;
                case 2:
                    caracterA = "*";
                    break;
                case -1:
                    caracterA = "X";
                    break;
                default:
                    caracterA= "-";
                    break;
            }
            Console.Write(caracterA+" ");
    
        }
        Console.WriteLine();
    }

        //IMPRIMIR EN PANTALLA SI SE GOLPEO UN BARCO O NO

            if (tablero[fila,columna] == 2)
            {
                Console.WriteLine($"Has golpeado un barco.\n");
                contador++;
            }
            else
            {
                Console.WriteLine("No has golpeado ningun barco, sigue intentando.\n");
            }

            if (contador == 5)
            {
                Console.WriteLine($">Felicidades!, has golpeado todos los barcos del tablero en {intentos} intentos.\n\n");
                Environment.Exit(0);
            }



 
}

//PEDIR AL USUARIO INGRESAR LA FILA Y COLUMNA EN LA QUE QUIERE ATACAR

void paso4()
{
    Console.Clear();
    do
    {
        Console.Write("Ingresa la fila: ");
        fila=int.Parse(Console.ReadLine()); fila -= 1;
        Console.Write("Ingresa la columna: ");
        columna = int.Parse(Console.ReadLine()); columna -= 1;
        intentos++;



//CAMBIAR EL VALOR DEPENDIENDO DE SI HABIA UN BARCO EN LA COORDENADA ESCRITA O NO
        if (tablero[fila,columna]==1)
        {
            Console.Beep();
            tablero[fila,columna] = 2;
        }
        else
        {
            tablero[fila,columna] = -1;
        }
        Console.Clear();

        paso3();
    } while (true);
}

//LLAMAR A TODOS LOS METODOS PASO X PASO

paso1();
paso2();
paso3();
paso4();


} 
catch 
{

    Console.Write($"Error, debe ingresar un numero entero acorde al tamaño del tablero.");
    
}
//FIN DEL PROGRAMA
}

Parcial();