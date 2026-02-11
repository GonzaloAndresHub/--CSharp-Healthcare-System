using System;

public class Healt
{
    public static void Main(String[] args)
    {

        Console.WriteLine(" Bienvenido Sistema de Triaje Clínico Inteligente");
        Console.WriteLine("\n Registro del Paciente");

        // Pedir datos al usuario
        Console.Write("Ingrese el nombre del paciente: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la edad del paciente: ");
        int edad = int.Parse(Console.ReadLine());


        // Debemos crear los Objetos de cada Clase
        Paciente paciente = new Paciente(nombre, edad);
        Menu menu = new Menu();

        // Se invocan los métodos de cada clase a través de sus instancias.
        // Flujo del sistema:
        // 1) El paciente se presenta y registra sus datos iniciales.
        // 2) Se muestra el menú principal asociado al paciente.
        // 3) El sistema de triaje evalúa la condición del paciente.
        paciente.Presentarse();
        menu.Mostrar(paciente);

        //Triaje triaje = new Triaje();
        //triaje.Evaluacion(paciente);


    }
}

/*=== PACIENTE ===*/
// Primero se crear la Clase dominante del programa
public class Paciente
{
    int contadorEmergencias = 0;
    int contadorUrgencias = 0;
    int contadorNormales = 0;

    //Propiedades Publicas
    public string Nombre { get; set; }
    public int Edad { get; set; }

    //Propiedades Privadas
    private int saturacionOxigeno;       
    private int frecuenciaCardiaca;
    private int umbralDolorNivel; 
    //private bool tieneSintomasCriticos = true; // true = Sí, false = No
    //private string nivelDeRiesgo;

    // Método Constructor de la Clase Paciente: 
    // Para que un Paciente exista (Objeto), debe cumplir estas reglas que son el Constructor
    // Define las reglas mínimas de creación y garantiza
    // que el objeto se inicialice en un estado válido.
    public Paciente(string nombre, int edad)
    {
        Nombre = nombre; //Debe tener nombre
        Edad = edad; // Debe tener edad
    }


    public void RegistrarSaturacion(int valor) // Paso 0
    {
        saturacionOxigeno = valor;

        if (saturacionOxigeno < 90)
        {
            Console.WriteLine("\n¡EMERGENCIA!");
            Console.WriteLine("Saturación CRÍTICA: la saturación de oxígeno sugiere emergencia médica.");
            //Necesito un contador
        }
        else if (saturacionOxigeno >= 90 && saturacionOxigeno <= 94)
        {
            Console.WriteLine("\n¡URGENTE!");
            Console.WriteLine("Saturación BAJA: la saturación de oxígeno indica hipoxemia leve, requiere vigilancia.");
            // Necesito un contador
        }
        else
        {
            Console.WriteLine("\nNORMAL");
            Console.WriteLine("Saturación NORMAL: oxigenación adecuada, dentro de los valores esperados (95% - 100%).");
            
        }
    }

    public void RegistrarFrecuencia(int valor)
    {
        frecuenciaCardiaca = valor;
    }

    public void RegistrarDolor(int nivel)
    {
        umbralDolorNivel = nivel;
    }

    public void MostrarEstadisticas()
    {
        Console.WriteLine("\n=== Estadísticas del paciente ===");
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Edad: " + Edad + " años");
        Console.WriteLine("Saturación: " + saturacionOxigeno + " %");
        Console.WriteLine("Frecuencia cardíaca: " + frecuenciaCardiaca + " lpm");
        Console.WriteLine("Nivel de dolor: " + umbralDolorNivel + "/10");
        Console.WriteLine("Emergencias: " + contadorEmergencias);
        Console.WriteLine("Urgencias: " + contadorUrgencias);
        Console.WriteLine("Normales: " + contadorNormales);
    }


    // Métodos para obtener datos
    public int ObtenerSaturacion() => saturacionOxigeno;
    public int ObtenerFrecuencia() => frecuenciaCardiaca;
    public int ObtenerDolor() => umbralDolorNivel;


    // Método Presentarse
    // Muestra en consola los datos básicos de identificación del paciente
    // utilizados como entrada inicial para el sistema de triaje.
    public void Presentarse()
    {
        Console.WriteLine("Mi nombre es: " + Nombre);
        Console.WriteLine("Mi Edad es: " + Edad + "Años");
    }
}

/*=== TRIAJE ===*/
class Triaje
{
    public void Evaluacion(Paciente paciente) //Método que evalúa el paciente
    {
        Console.WriteLine("\nEvaluar la Emergencia: ");

        Console.WriteLine("=== MENÚ DE EVALUACIÓN ===");
        Console.WriteLine("1. Vamos a valorar su Saturación");
        Console.WriteLine("2. Vamos a valorar su Frecuencia Cardiaca");
        Console.WriteLine("3. Medir Umbral del Dolor");
        Console.WriteLine("4. Cuestionario de Sintomas Criticos");
        int menuEva = int.Parse(Console.ReadLine());

        switch (menuEva)
        {


            case 1:
                Console.WriteLine("Ingrese la Saturación de Oxigeno: ");
                int saturacionOxigeno = int.Parse(Console.ReadLine());

                //Paso 1
                paciente.RegistrarSaturacion(saturacionOxigeno);

                Console.WriteLine("La Saturación de Oxigeno del Paciente es: " + saturacionOxigeno + " %");
                break;

            case 2:
                Console.WriteLine("Ingrese la Frecuencia Cardiaca: ");
                int frecuenciaCardiaca = int.Parse(Console.ReadLine());
                paciente.RegistrarFrecuencia(frecuenciaCardiaca); // guardar en el objeto

                Console.WriteLine("La Frecuencia Cardiaca del Paciente es: " + frecuenciaCardiaca + " lpm");

                if (frecuenciaCardiaca < 60)
                {
                    Console.WriteLine("Bradicardia: Indica que el paciente requiere valoración.");
                }
                else if (frecuenciaCardiaca >= 60 && frecuenciaCardiaca <= 100)
                {
                    Console.WriteLine("Normal: Frecuencia cardíaca adecuada en reposo.");
                }
                else if (frecuenciaCardiaca >= 101 && frecuenciaCardiaca <= 140)
                {
                    Console.WriteLine("Taquicardia leve a moderada: Ritmo acelerado, puede deberse a estrés, fiebre, deshidratación o problemas cardíacos.");
                }
                else if (frecuenciaCardiaca > 140)
                {
                    Console.WriteLine("Taquicardia grave: Riesgo clínico, requiere atención médica inmediata");
                }
                else
                {
                    Console.WriteLine("Error: debes volver a registrar la frecuencia cardíaca.");
                }
                break;

            case 3:
                Console.WriteLine("En una escala de 0 a 10, ¿Qué número describe mejor su dolor ahora?");
                int umbralDolorNivel = int.Parse(Console.ReadLine());
                paciente.RegistrarDolor(umbralDolorNivel); // guardar en el objeto


                if (umbralDolorNivel == 0)
                {
                    Console.WriteLine("Sin dolor: el paciente indica un nivel de 0 en la escala de 0 a 10.");
                }
                else if (umbralDolorNivel >= 1 && umbralDolorNivel <= 3)
                {
                    Console.WriteLine("Dolor LEVE: molestias tolerables, no limitan actividades.");
                }
                else if (umbralDolorNivel >= 4 && umbralDolorNivel <= 6)
                {
                    Console.WriteLine("Dolor MODERADO: interfiere con actividades, requiere manejo clínico.");
                }
                else if (umbralDolorNivel >= 7 && umbralDolorNivel <= 10)
                {
                    Console.WriteLine("Dolor INTENSO: nivel máximo, requiere atención inmediata.");
                }
                else
                {
                    Console.WriteLine("Valor inválido: la escala de dolor es de 0 a 10.");
                }
                break;

            case 4:
                Console.WriteLine("¿El paciente tiene sintomas Criticos?");
                Console.WriteLine("1. SI");
                Console.WriteLine("2. NO");

                int sintomaCritico = int.Parse(Console.ReadLine());
                break;

            default:
                Console.WriteLine("Algo salio mal: Inténtalo de nuevo");
                break;
        }
    }
    //Retorna el nivel: Emergencia / Urgente / Normal
}

/*=== MENÚ ===*/
class Menu //Las instrucciones de la Clase Menú deben estar dentro de un Método
{
    public void Mostrar(Paciente paciente)
    {
        int opcion = 0;

        while (opcion != 3)
        {
            Console.WriteLine("==== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Registrar paciente");
            Console.WriteLine("2. Mostrar estadísticas");
            Console.WriteLine("3. Salir");

            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)

            {
                case 1:
                    Triaje triaje = new Triaje();
                    triaje.Evaluacion(paciente);
                    break;


                case 2:
                    paciente.MostrarEstadisticas();
                    break;

                case 3:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;

            }

        }

    }
}
