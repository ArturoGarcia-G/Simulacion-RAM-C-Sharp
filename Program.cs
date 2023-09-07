int opc, tamaño, posicion = 0, posicionTamaños = 0, posicionNombre = 0, estado=0;
char nombre = ' ';
int[] listaTamaños = new int[32];
int[] valoresRAM = new int[32];
int[] valoresVirtual = new int[32];
int[] estadosRam = new int[32];
int[] estadosVirtual = new int[32];
char[] memoriaRAM = new char[32];
char[] memoriaVirtual = new char[32];
int[] listaHuecosRAM = new int[32];
int[] inicioHuecosRAM = new int[32];
int[] listaHuecosVirtual = new int[32];
int[] inicioHuecosVirtual = new int[32];
int[] listaProcesosRAM = new int[32];
int[] inicioProcesosRAM = new int[32];
int[] estadoProcesosRAM = new int[32];
int[] listaProcesosVirtual = new int[32];
int[] inicioProcesosVirtual = new int[32];
int[] estadoProcesosVirtual = new int[32];

void revisarHuecos()
{
    // Huecos que hay en memoria RAM 
    int anterior = -1, actual = -1, tam = 0, fin;
    char nombreActual;
    for(int i = 0; i < 32; i++)
    {
        listaHuecosRAM[i] = 0;
        listaHuecosVirtual[i] = 0;
        inicioHuecosRAM[i] = 0;
        inicioHuecosVirtual[i] = 0;
    }
    int h = 0;
    for (int x = 0; x < 32; x++)
    {
        actual = valoresRAM[x];
        nombreActual = memoriaRAM[x];
        char nombreSiguiente = nombreActual;

        if (actual != anterior)
        {
            if (x == 31)
            {
                fin = 32;
            }
            else
            {
                fin = x;

                int y = x + 1;
                nombreSiguiente = memoriaRAM[y];

                if (nombreSiguiente.Equals(nombreActual) == false)
                {
                    fin++;
                }



                while (nombreSiguiente.Equals(nombreActual) == true && y <= 31)
                {
                    nombreSiguiente = memoriaRAM[y];
                    fin++;
                    y++;

                    if (y == 32)
                        fin = 32;

                }
            }


            if (memoriaRAM[x].Equals('H') == true)
            {
                listaHuecosRAM[h] = fin - x;
                inicioHuecosRAM[h] = x;
                h++;
            }

            
            tam++;
        }
        anterior = actual;



    }

    //Huecos que hay en memoria virtual 

    anterior = -1; actual = -1; tam = 0; fin = 0;
    nombreActual = ' ';
    h = 0;
    for (int x = 0; x < 32; x++)
    {
        actual = valoresVirtual[x];
        nombreActual = memoriaVirtual[x];
        char nombreSiguiente = nombreActual;

        if (actual != anterior)
        {
            if (x == 31)
            {
                fin = 32;
            }
            else
            {
                fin = x;

                int y = x + 1;
                nombreSiguiente = memoriaVirtual[y];

                if (nombreSiguiente.Equals(nombreActual) == false)
                {
                    fin++;
                }



                while (nombreSiguiente.Equals(nombreActual) == true && y <= 31)
                {
                    nombreSiguiente = memoriaVirtual[y];
                    fin++;
                    y++;

                    if (y == 32)
                        fin = 32;

                }
            }


            if (memoriaVirtual[x].Equals('H') == true)
            {
                listaHuecosVirtual[h] = fin - x;
                inicioHuecosVirtual[h] = x;
                h++;
            }

            
            tam++;
        }
        anterior = actual;

    }

   

    

}

void revisarProcesos()
{
    // Procesos que hay en memoria RAM 
    int anterior = -1, actual = -1, tam = 0, fin;
    char nombreActual;
    for (int i = 0; i < 32; i++)
    {
        listaProcesosRAM[i] = 0;
        listaProcesosVirtual[i] = 0;
        inicioProcesosRAM[i] = 0;
        inicioProcesosVirtual[i] = 0;
    }
    int h = 0;
    for (int x = 0; x < 32; x++)
    {
        actual = valoresRAM[x];
        nombreActual = memoriaRAM[x];
        char nombreSiguiente = nombreActual;

        if (actual != anterior)
        {
            if (x == 31)
            {
                fin = 32;
            }
            else
            {
                fin = x;

                int y = x + 1;
                nombreSiguiente = memoriaRAM[y];

                if (nombreSiguiente.Equals(nombreActual) == false)
                {
                    fin++;
                }



                while (nombreSiguiente.Equals(nombreActual) == true && y <= 31)
                {
                    nombreSiguiente = memoriaRAM[y];
                    fin++;
                    y++;

                    if (y == 32)
                        fin = 32;

                }
            }


            if (memoriaRAM[x].Equals('H') == false)
            {
                listaProcesosRAM[h] = fin - x;
                inicioProcesosRAM[h] = x;
                estadoProcesosRAM[h] = estadosRam[x];
                h++;
            }

            
            tam++;
        }
        anterior = actual;



    }

    //Procesos que hay en memoria virtual 

    anterior = -1; actual = -1; tam = 0; fin = 0;
    nombreActual = ' ';
    h = 0;
    for (int x = 0; x < 32; x++)
    {
        actual = valoresVirtual[x];
        nombreActual = memoriaVirtual[x];
        char nombreSiguiente = nombreActual;

        if (actual != anterior)
        {
            if (x == 31)
            {
                fin = 32;
            }
            else
            {
                fin = x;

                int y = x + 1;
                nombreSiguiente = memoriaVirtual[y];

                if (nombreSiguiente.Equals(nombreActual) == false)
                {
                    fin++;
                }



                while (nombreSiguiente.Equals(nombreActual) == true && y <= 31)
                {
                    nombreSiguiente = memoriaVirtual[y];
                    fin++;
                    y++;

                    if (y == 32)
                        fin = 32;

                }
            }


            if (memoriaVirtual[x].Equals('H') == false)
            {
                listaProcesosVirtual[h] = fin - x;
                inicioProcesosVirtual[h] = x;
                estadoProcesosVirtual[h] = estadosVirtual[x];
                h++;
            }

            tam++;
        }
        anterior = actual;

    }

}

void insertarProceso(char nombre, int tamaño, int estado, int pid)
{
    revisarHuecos();
    // Insertar proceso en ejecucion
    int procesoInsertado = 0;
    if (estado == 1)
    {
        Console.WriteLine("Proceso de estado ejecucion");
        // Revisa si hay huecos del tamaño suficiente para el proceso en la RAM
        for (int i = 0; i < 32 && procesoInsertado==0; i++)
        {
            if(listaHuecosRAM[i] >= tamaño)
            {
                for (int j = inicioHuecosRAM[i]; j<(inicioHuecosRAM[i]+tamaño) ; j++)
                {
                    memoriaRAM[j] = nombre;
                    valoresRAM[j] = pid;
                    estadosRam[j] = estado;
                }
                procesoInsertado = 1;
            }
        }

        // Revisa si hay procesos que no esten en ejecucion y que sean del tamaño suficiente para moverlos
        revisarProcesos();
        for(int i = 0;i < 32 && procesoInsertado == 0;i++)
        {
            
            if(estadoProcesosRAM[i]==2 || estadoProcesosRAM[i]==3)
            {
                if (listaProcesosRAM[i]>= tamaño)
                {
                    
                    char nombreAux = memoriaRAM[inicioProcesosRAM[i]];
                    int pidAux = valoresRAM[inicioProcesosRAM[i]];
                    //Al encontrar un proceso para mover, comiemza elimindando el proceso de la memoria 
                    for (int x = inicioProcesosRAM[i]; x < (inicioProcesosRAM[i] + listaProcesosRAM[i]); x++)
                    {
                        memoriaRAM[x] = 'H';
                        valoresRAM[x] = 0;
                        estadosRam[x] = 0;
                    }

                    // Se inserta el nuevo proceso
                    for (int j = inicioProcesosRAM[i]; j < (inicioProcesosRAM[i] + tamaño); j++)
                    {
                        memoriaRAM[j] = nombre;
                        valoresRAM[j] = pid;
                        estadosRam[j] = estado;
                    }
                    procesoInsertado = 1;

                    // Se inserta el proceso anterior en alguna otra parte 
                    insertarProceso(nombreAux, listaProcesosRAM[i], estadoProcesosRAM[i], pidAux);

                }
            }
        }

        // Si no se puede insertar en la memoria RAM, se cambia el estado a espera y se inserta (por logica se terminara insertando en la memoria virtual)
        if (procesoInsertado==0)
        {
            estado = 3;
            insertarProceso(nombre, tamaño, estado, pid);
            procesoInsertado = 1;
        }
    }
    else if (estado==2)
    {
        Console.WriteLine("Proceso de estado listo");
        // Revisa si hay huecos del tamaño suficiente para el proceso en la RAM
        for (int i = 0; i < 32 && procesoInsertado == 0; i++)
        {
            if (listaHuecosRAM[i] >= tamaño)
            {
                for (int j = inicioHuecosRAM[i]; j < (inicioHuecosRAM[i] + tamaño); j++)
                {
                    memoriaRAM[j] = nombre;
                    valoresRAM[j] = pid;
                    estadosRam[j] = estado;
                }
                procesoInsertado = 1;
            }
        }

        // Revisa si hay huecos del tamaño suficiente para el proceso en la M.V
        for (int i = 0; i < 32 && procesoInsertado == 0; i++)
        {
            if (listaHuecosVirtual[i] >= tamaño)
            {
                for (int j = inicioHuecosVirtual[i]; j < (inicioHuecosVirtual[i] + tamaño); j++)
                {
                    memoriaVirtual[j] = nombre;
                    valoresVirtual[j] = pid;
                    estadosVirtual[j] = estado;
                }
                procesoInsertado = 1;
            }
        }
        // Revisa si hay procesos en estado de espera y que sean del tamaño suficiente para poder eliminarlos e insertar el proceso en su lugar 
        revisarProcesos();
        for (int i = 0; i < 32 && procesoInsertado == 0; i++)
        {

            if (estadoProcesosVirtual[i] == 3)
            {
                if (listaProcesosVirtual[i] >= tamaño)
                {
                   
                    //Al encontrar un proceso para mover, comiemza eliminando el proceso de la memoria 
                    for (int x = inicioProcesosVirtual[i]; x < (inicioProcesosVirtual[i] + listaProcesosVirtual[i]); x++)
                    {
                        memoriaVirtual[x] = 'H';
                        valoresVirtual[x] = 0;
                        estadosVirtual[x] = 0;
                    }

                    // Se inserta el nuevo proceso
                    for (int j = inicioProcesosVirtual[i]; j < (inicioProcesosVirtual[i] + tamaño); j++)
                    {
                        memoriaVirtual[j] = nombre;
                        valoresVirtual[j] = pid;
                        estadosVirtual[j] = estado;
                    }
                    procesoInsertado = 1;

                    

                }
            }
        }

        procesoInsertado = 1;

    }
    else if(estado==3)
    {
        Console.WriteLine("Proceso de estado espera");
        // Revisa si hay huecos del tamaño suficiente para el proceso en la RAM
        for (int i = 0; i < 32 && procesoInsertado == 0; i++)
        {
            if (listaHuecosRAM[i] >= tamaño)
            {
                for (int j = inicioHuecosRAM[i]; j < (inicioHuecosRAM[i] + tamaño); j++)
                {
                    memoriaRAM[j] = nombre;
                    valoresRAM[j] = pid;
                    estadosRam[j] = estado;
                }
                procesoInsertado = 1;
            }
        }

        // Revisa si hay huecos del tamaño suficiente para el proceso en la M.V
        for (int i = 0; i < 32 && procesoInsertado == 0; i++)
        {
            if (listaHuecosVirtual[i] >= tamaño)
            {
                for (int j = inicioHuecosVirtual[i]; j < (inicioHuecosVirtual[i] + tamaño); j++)
                {
                    memoriaVirtual[j] = nombre;
                    valoresVirtual[j] = pid;
                    estadosVirtual[j] = estado;
                }
                procesoInsertado = 1;
            }
        }

        procesoInsertado = 1; 

        
    }

    // 


}

for (int i = 0; i < 32; i++)
{
    memoriaRAM[i] = 'H';
    memoriaVirtual[i] = 'H';
    valoresRAM[i] = 0;
    valoresVirtual[i] = 0;
}

do
{
    Console.WriteLine("");
    Console.WriteLine("------Menu---------");
    Console.WriteLine("1. Agregar proceso");
    Console.WriteLine("2. Finalizar Proceso");
    Console.WriteLine("3. Mostrar memoria");
    Console.WriteLine("4. Compactar");
    Console.WriteLine("5. Ejecucion por ciclo");
    Console.WriteLine("6. Salir");
    Console.WriteLine("-------------------");
    opc = int.Parse(Console.ReadLine());

    if (opc == 1)
    {
        Console.WriteLine("Tamaño del proceso:");
        tamaño = int.Parse(Console.ReadLine());
        Console.WriteLine("Nombre del proceso:");
        nombre = char.Parse(Console.ReadLine());
        if (tamaño > 32)
        {
            Console.WriteLine("Excede la capacidad de la memoria");

        }
        int randomNumber = new Random().Next(1, 10);
        if (randomNumber <= 4)
        {
            estado = 1;

        }
        else if (randomNumber > 4 && randomNumber <= 7)
        {
            estado = 2;

        }
        else if (randomNumber > 7 && randomNumber <= 10)
        {
            estado = 3;

        }
        int pid = new Random().Next(100, 1000);

        insertarProceso(nombre, tamaño, estado, pid);



    }
    else if (opc == 2)
    {
        Console.WriteLine("1. Finalizar por cola");
        Console.WriteLine("2. Finalizar por PID");
        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 1)
        {
            revisarProcesos();
            for (int i = inicioProcesosRAM[0]; i < (inicioProcesosRAM[0] + listaProcesosRAM[0]); i++)
            {
                memoriaRAM[i] = 'H';
                estadosRam[i] = 0;
                valoresRAM[i] = 0;
            }
        }
        else if (opcion == 2)
        {
            Console.WriteLine("Proceso a borrar:");
            char proceso = char.Parse(Console.ReadLine());
            revisarProcesos();
            for (int i = 0; i < 32; i++)
            {
                if (memoriaRAM[inicioProcesosRAM[i]] == proceso)
                {
                    for (int j = inicioProcesosRAM[i]; j < (inicioProcesosRAM[i] + listaProcesosRAM[i]); j++)
                    {
                        memoriaRAM[j] = 'H';
                        estadosRam[j] = 0;
                        valoresRAM[j] = 0;
                    }
                }
                else if (memoriaVirtual[inicioProcesosVirtual[i]] == proceso)
                {
                    for (int j = inicioProcesosVirtual[i]; j < (inicioProcesosVirtual[i] + listaProcesosVirtual[i]); j++)
                    {
                        memoriaVirtual[j] = 'H';
                        estadosVirtual[j] = 0;
                        valoresVirtual[j] = 0;
                    }
                }
            }


        }
    }
    else if (opc == 3)
    {
        Console.WriteLine();
        Console.WriteLine("---MEMORIA RAM---");
        // Mostrar RAM
        Console.Write("[");
        for (int x = 0; x < 32; x++)
        {
            if (estadosRam[x] == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (estadosRam[x] == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (estadosRam[x] == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write(" " + memoriaRAM[x]);
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.Write("]");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        // Mostrar Virtual
        Console.WriteLine("---MEMORIA VIRTUAL---");
        Console.Write("[");
        for (int x = 0; x < 32; x++)
        {
            if (estadosVirtual[x] == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (estadosVirtual[x] == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (estadosVirtual[x] == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write(" " + memoriaVirtual[x]);
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.Write("]");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        // Mapa de bits
        Console.WriteLine("---MAPA DE BITS (MEMORIA RAM)---");
        for (int x = 0;x < 32;x++)
        {
            if(memoriaRAM[x].Equals('H')==false)
            {
                Console.Write("[");
                Console.Write("1");
                Console.Write("]");
            }
            else
            {
                Console.Write("[");
                Console.Write("0");
                Console.Write("]");
            }

            if (x==7 || x==15 || x==23)
            {
                Console.WriteLine("");
            }
        }
        Console.WriteLine("");
        
        Console.WriteLine("");
        Console.WriteLine("---LISTA DE HUECOS (MEMORIA RAM)---");
        // Lista de huecos
        int anterior = -1, actual = -1, tam = 0, fin;
        char nombreActual;
       
        int h = 0;
        for (int x = 0; x < 32; x++)
        {
            actual = valoresRAM[x];
            nombreActual = memoriaRAM[x];
            char nombreSiguiente = nombreActual;

            if (actual != anterior)
            {
                if (x == 31)
                {
                    fin = 32;
                }
                else
                {
                    fin = x;

                    int y = x + 1;
                    nombreSiguiente = memoriaRAM[y];

                    if (nombreSiguiente.Equals(nombreActual) == false)
                    {
                        fin++;
                    }



                    while (nombreSiguiente.Equals(nombreActual) == true && y <= 31)
                    {
                        nombreSiguiente = memoriaRAM[y];
                        fin++;
                        y++;

                        if (y == 32)
                            fin = 32;

                    }
                }

                char valor=' ';
                if (memoriaRAM[x].Equals('H') == true)
                {
                    valor = 'H';                 
                }
                else
                {
                    valor = 'P';
                }
                Console.Write("[" + x + "]" + "[" +valor + "]" + "[" + (fin-1) + "] " );

            }
            anterior = actual;



        }
        Console.WriteLine("");
        
        Console.WriteLine("");
        Console.WriteLine("---LISTA DE HUECOS (MEMORIA RAM)---");
        // Lista de huecos
        anterior = -1; actual = -1; tam = 0; fin=0;
        nombreActual=' ';

        h = 0;
        for (int x = 0; x < 32; x++)
        {
            actual = valoresRAM[x];
            nombreActual = memoriaRAM[x];
            char nombreSiguiente = nombreActual;

            if (actual != anterior)
            {
                if (x == 31)
                {
                    fin = 32;
                }
                else
                {
                    fin = x;

                    int y = x + 1;
                    nombreSiguiente = memoriaRAM[y];

                    if (nombreSiguiente.Equals(nombreActual) == false)
                    {
                        fin++;
                    }



                    while (nombreSiguiente.Equals(nombreActual) == true && y <= 31)
                    {
                        nombreSiguiente = memoriaRAM[y];
                        fin++;
                        y++;

                        if (y == 32)
                            fin = 32;

                    }
                }

                
                Console.Write("[" + x + "]" + "[" + memoriaRAM[x] + "]" + "[" + (fin - 1) + "] ");

            }
            anterior = actual;



        }


    }
    else if (opc == 4)
    {
        Console.WriteLine("1.Compactar RAM");
        Console.WriteLine("2.Compactar M.V");
        int opcion = int.Parse(Console.ReadLine()); 

        if (opcion== 1)
        {
            // Compactar RAM
            revisarHuecos();

            while (inicioHuecosRAM[0] + listaHuecosRAM[0] != 32)
            {
                for (int y = inicioHuecosRAM[0]; y < (32 - listaHuecosRAM[0]); y++)
                {
                    memoriaRAM[y] = memoriaRAM[y + listaHuecosRAM[0]];
                    valoresRAM[y] = valoresRAM[y + listaHuecosRAM[0]];
                    estadosRam[y] = estadosRam[y + listaHuecosRAM[0]];
                }
                for (int z = 31; z > (31 - listaHuecosRAM[0]); z--)
                {
                    memoriaRAM[z] = 'H';
                    valoresRAM[z] = 0;
                    estadosRam[z] = 0;
                }
                revisarHuecos();

            }
        }
        else if (opcion==2)
        {
            // Compactar M.V
            revisarHuecos();

            while (inicioHuecosVirtual[0] + listaHuecosVirtual[0] != 32)
            {
                for (int y = inicioHuecosVirtual[0]; y < (32 - listaHuecosVirtual[0]); y++)
                {
                    memoriaVirtual[y] = memoriaVirtual[y + listaHuecosVirtual[0]];
                    valoresVirtual[y] = valoresVirtual[y + listaHuecosVirtual[0]];
                    estadosVirtual[y] = estadosVirtual[y + listaHuecosVirtual[0]];
                }
                for (int z = 31; z > (31 - listaHuecosVirtual[0]); z--)
                {
                    memoriaVirtual[z] = 'H';
                    valoresVirtual[z] = 0;
                    estadosVirtual[z] = 0;
                }
                revisarHuecos();

            }
        }
        

    }
    else if (opc==5)
    {
        Console.WriteLine("1. Cambiar estado de un proceso");
        Console.WriteLine("2. Cambiar estados aleatoriamente");
        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 1)
        {
            Console.WriteLine("Proceso a cambiar: ");
            char proceso = char.Parse(Console.ReadLine());
            Console.WriteLine("Estado nuevo: ");
            Console.WriteLine("1. Ejecucion");
            Console.WriteLine("2. Listo");
            Console.WriteLine("3. Espera");
            int nuevoEstado = int.Parse(Console.ReadLine());

            revisarProcesos();

            for(int i = 0; i < 32; i++)
            {
                if (memoriaRAM[inicioProcesosRAM[i]] == proceso) 
                {
                    
                    char nombreAux = memoriaRAM[inicioProcesosRAM[i]];
                    int pidAux = valoresRAM[inicioProcesosRAM[i]];
                  
                    for (int x = inicioProcesosRAM[i]; x < (inicioProcesosRAM[i] + listaProcesosRAM[i]); x++)
                    {
                        memoriaRAM[x] = 'H';
                        valoresRAM[x] = 0;
                        estadosRam[x] = 0;
                    }

                    // Se inserta el proceso nuevamente  
                    insertarProceso(nombreAux, listaProcesosRAM[i], nuevoEstado, pidAux);

                }

                else if (memoriaVirtual[inicioProcesosVirtual[i]] == proceso)
                        {
                            Console.WriteLine("Proceso encontado, cambiando...");
                            char nombreAux = memoriaVirtual[inicioProcesosVirtual[i]];
                            int pidAux = valoresVirtual[inicioProcesosVirtual[i]];

                            for (int x = inicioProcesosVirtual[i]; x < (inicioProcesosVirtual[i] + listaProcesosVirtual[i]); x++)
                            {
                                memoriaVirtual[x] = 'H';
                                valoresVirtual[x] = 0;
                                estadosVirtual[x] = 0;
                            }

                            // Se inserta el proceso nuevamente  
                            insertarProceso(nombreAux, listaProcesosVirtual[i], nuevoEstado, pidAux);

                        }
            }

        }
        else if(opcion==2)
        {

            
            revisarProcesos();

            for (int i = 0; i < 32; i++)
            {
                if (memoriaRAM[inicioProcesosRAM[i]] != 'H')
                {
                    Console.WriteLine("Proceso encontado, cambiando...");
                    char nombreAux = memoriaRAM[inicioProcesosRAM[i]];
                    int pidAux = valoresRAM[inicioProcesosRAM[i]];

                    for (int x = inicioProcesosRAM[i]; x < (inicioProcesosRAM[i] + listaProcesosRAM[i]); x++)
                    {
                        memoriaRAM[x] = 'H';
                        valoresRAM[x] = 0;
                        estadosRam[x] = 0;
                    }

                    // Se inserta el proceso nuevamente  
                    insertarProceso(nombreAux, listaProcesosRAM[i], new Random().Next(1, 3), pidAux);

                }

                if (memoriaVirtual[inicioProcesosVirtual[i]] !='H')
                {
                    Console.WriteLine("Proceso encontado, cambiando...");
                    char nombreAux = memoriaVirtual[inicioProcesosVirtual[i]];
                    int pidAux = valoresVirtual[inicioProcesosVirtual[i]];

                    for (int x = inicioProcesosVirtual[i]; x < (inicioProcesosVirtual[i] + listaProcesosVirtual[i]); x++)
                    {
                        memoriaVirtual[x] = 'H';
                        valoresVirtual[x] = 0;
                        estadosVirtual[x] = 0;
                    }

                    // Se inserta el proceso nuevamente  
                    insertarProceso(nombreAux, listaProcesosVirtual[i], new Random().Next(1, 3), pidAux);

                }
            }

        }
    }



} while (opc != 6);

