using System;
using System.Collections.Generic;


namespace ReconstruirATraves
{

//LINEAMIENTOS BASE JUEGO E INICIO
    class Program
    {
        static void Main()
        {
            Juego juego = new Juego();
            juego.Iniciar();
        }
    }


    class Juego
    { //PARA LOS TEXTOS LINDOS
        bool primerBoton = true;

        public void Texto(string texto)
        {
            Console.WriteLine();
            Console.WriteLine(texto);
        }

        public void Divisor()
        {
            Console.WriteLine();
            Console.WriteLine("==============================");
        }

        public void Boton(string texto)
        {
            Console.WriteLine();
            if (primerBoton == true)
            {
                Console.Write("   # " + texto + "  (presiona Enter)");
                primerBoton = false;
            }
            else
            {
                Console.Write("   # " + texto);
            }
            Console.ReadLine();
        }

        // Función OPCIONES: mostrar, elegir, eliminar
        public string Menu(List<string> opciones)
        {
            Console.WriteLine();
            for (int i = 0; i < opciones.Count; i++)
            {
                Console.WriteLine("   " + (i + 1) + ". " + opciones[i]);
            }
            int numero = 0;
            while (numero < 1 || numero > opciones.Count)

            {
                Console.Write("Elige una opción: ");
                string? respuesta = Console.ReadLine();
                int.TryParse(respuesta, out numero);
            }

            string elegida = opciones[numero - 1];
            opciones.RemoveAt(numero - 1);
            return elegida;
        }

        // Función LLER ITEM (pg y btn)
        public void LeerPaginas(string[] paginas, string[] botones)
        {
            for (int i = 0; i < paginas.Length; i++)
            {
                Texto(paginas[i]); //mostrar pg y bt previo
                Boton(botones[i]);
            }
        }


        void Fin()
        {
            Texto("========== FIN ==========");
            Boton("Volver a empezar");
        }

        public void Iniciar()
        {
            // Empieza en la sala principal
            SalaPrincipal();
        }

        // SALA PRINCIPALA

        void SalaPrincipal()
        {
            Divisor();
            Texto("Abres los ojos. No recuerdas cómo llegaste aquí. \n Estás en la mitad de una sala de una casa que huele a polvo y humedad.");
            Boton("Mirar alrededor");

            Texto("Hay sofás viejos, mesas con moho, \nlibros sucios con relicarios y fotografías encima, \ny una vajilla sucia que apesta a podredumbre.");
            Boton("Continuar");


            Texto("Frente a ti se resaltan 2 puertas:\nLa primera es de madera y tiene rasguños alrededor del picaporte.\nLa segunda, una puerta metálica con una pequeña ventana de vidrio esmerilado.\n\nDetrás, hay una puerta que indica que es la salida.");

            // lista opciones
            List<string> opciones = new List<string> { "Mirar fotos", "Intentar salir" };
            while (opciones.Count > 0)
            {
                string eleccion = Menu(opciones);

                if (eleccion == "Mirar fotos")
                {
                    Texto("Ves rostros que te hacen sentir familiar, y particularmente uno se parece al tuyo. \nTodas las fotos tienen fecha del mismo año, pero no hay nombres.\nEscalofríos recorren tu cuerpo.\n“¿Quién soy y qué vine a buscar?” te preguntas.");
                    Boton("Volver atrás");

                    opciones.Add("Abrir la puerta de madera");
                    opciones.Add("Abrir la puerta de metal");
                }


                else if (eleccion == "Intentar salir")
                {
                    Texto("Esa puerta de salida es tu oportunidad, con desespero por irte te abalanzas ante ella. \nEstá bloqueada, no puedes salir.");
                    Boton("Volver atrás");
                }

                else if (eleccion == "Abrir la puerta de madera")
                {
                    // FUNCIÓN PARA NARRATIVA 1
                    PuertaMadera();
                    return;
                }

                    // FUNCIÓN PARA NARRATIVA 2
                else if (eleccion == "Abrir la puerta de metal")
                {
                    PuertaMetal[] puertasMetal = { new PuertaMetal(this) };
                    puertasMetal[0].Entrar();
                    return;
                }
            }
        }

        // NARRATIVA 1

        void PuertaMadera()
        {
            Divisor();
            Texto("La puerta cruje al abrirse. \nDel otro lado, un pasillo corto con papel tapiz descascarado. \nEn el suelo, ves unos objetos");


            List<string> opciones = new List<string> { "Inspeccionar caja", "Inspeccionar identificaciones" };
            while (opciones.Count > 0)
            {
                string eleccion = Menu(opciones);
                if (eleccion == "Inspeccionar caja")
                {
                    Texto("La caja es ligeramente pesada. \nEs de cartón y está sellada pero la sientes un poco fría al tomarla. \nUna nota encima dice: “Si quieres salir, no puedes dejar ninguna pista atrás”.");
                    Boton("Continuar");
                }

                else if (eleccion == "Inspeccionar identificaciones")
                {
                    Texto("La tarjeta de identificación está pelada en muchos datos, solo se distingue el nombre “Denis Welsch” y la persona de la foto es la misma mujer de las fotos de antes.\nHay otra tarjeta, una licencia de conducir. Te distingues a ti mismo en la foto, es tu tarjeta y tu nombre es Patrick Welsch.");
                    Boton("Continuar");
                }
            }


            List<string> puertas = new List<string> { "Abrir puerta infantil", "Abrir puerta elegante" };
            Texto("Al fondo de la habitación hay dos nuevas puertas:\nUna es pequeña, pero no te costará trabajo entrar. Tiene rayones de colores y dibujos de niño.\nLa otra es amplia y llena de mosaicos y vidrios elegantes.");

            while (puertas.Count > 0)
            {
                string eleccion = Menu(puertas);
                if (eleccion == "Abrir puerta infantil")
                {
                    PuertaInfantil();
                }


                else if (eleccion == "Abrir puerta elegante")
                {

                    PuertaElegante();
                }

                // Si todavía falta una puerta, el jugador vuelve a la habitación anterior
                if (puertas.Count > 0)
                {
                    Divisor();
                    Texto("Has vuelto a la habitación anterior. No olvides tus pistas.");
                }
            }

//solo entonces llega a la sala final funebre
            SalaFunebre();
        }

        void PuertaInfantil()
        {
            Divisor();
            Texto("Es un cuarto pequeño. \nPapel tapiz con dibujos de animales, descolorido por el tiempo. \nUna cama individual, deshecha. \nSobre la mesa de noche, otra caja y un diario de tapa azul con un cierre roto.");


            List<string> opciones = new List<string> { "Inspeccionar caja", "Leer diario" };
            while (opciones.Count > 0)
            {
                string eleccion = Menu(opciones);

                if (eleccion == "Inspeccionar caja")
                {

                    Texto("La caja es similar a la anterior, pesa un poco más. \nAgarras un maletín cercano a la mesa de noche para cargar las cajas.");

                    Boton("Continuar");
                }

                else if (eleccion == "Leer diario")
                {
                    //ARRAY PG DIARIO
                    string[] paginas =
                    {
                        // Página 1
                        "“Primer día de escuela de mi pequeñín. \nA veces siento que me pierdo en mí misma y cuando vuelvo a la realidad, él ya ha crecido por completo”",
                        // Página 2
                        "“Olª mamita t dejé un abraso en este cuadernito pªra q nunca t sientªs solA”",
                        // Página 3
                        "“Mi Patrick ya casi se gradúa, aunque esté grande siempre lo veré con mis ojos de mamá, \nviendo al niño que le gustaba rayar las puertas para que tuvieran más color. \nOjalá no tuviera que irme…”",
                        // Página 4
                        "“Hay personas curiosas en mi nuevo trabajo, queda muy lejos de casa así que Patrick se queda solo. \nPero está bien. Tengo que pagar sus estudios para que se convierta en el piloto que quiere ser”",
                        // Página 5
                        "“Dicen que la zona se ha vuelto peligrosa. \nHay asesinatos nuevos cada noche. Aún me siento intranquila y observada, \nsobretodo por ese hombre de la esquina de la oficina que nunca habla. \nYa solo quiero descansar y volver a casa, dejar de escribir tantas cosas y hablar con Patrick de su vida. \nExtraño a mi niño”."
                    };

                    string[] botones = { "Siguiente página", "Siguiente página", "Siguiente página", "Última página", "Cerrar diario" };
                    LeerPaginas(paginas, botones);
                }
            }

            List<string> salida = new List<string> { "Buscar una salida" };
            Menu(salida);
            Texto("Solo hay una escotilla. \nTe paras en la cama pequeña y sales por el techo de la habitación");
            Boton("Continuar");
        }

        void PuertaElegante()
        {
            // Separa este cuarto del anterior
            Divisor();
            // Muestra la descripción del cuarto
            Texto("Un cuarto decorado con un gusto casi impecable. \nCortinas pesadas, un tocador con espejo ovalado. \nSobre el tocador, un tarro de pastillas y una prescripción médica.");

            List<string> opciones = new List<string> { "Inspeccionar pastillas", "Empacar caja nueva" };
            while (opciones.Count > 0)
            {
                string eleccion = Menu(opciones);

                if (eleccion == "Inspeccionar pastillas")
                {
                    Texto("Son pastillas para la amnesia. Tienen tu nombre escrito en él y la letra de tu madre con un recordatorio para darte la medicina en las comidas.\n“Supongo que por eso no recordaba nada…” reflexionas.");
                    Boton("Continuar");
                }
                else if (eleccion == "Empacar caja nueva")
                {
                    Texto("Empacas la caja nueva, casi mismo tamaño y peso que la anterior.");
                    Boton("Continuar");
                }
            }

            List<string> salida = new List<string> { "Buscar una salida" };
            Menu(salida);
            Texto("Debajo de un tapiz, hay un hueco con escaleras hacia abajo. Al ver que no hay más salida, decides bajar por ahí.");
            Boton("Continuar");
        }

        void SalaFunebre()
        {
            Divisor();
            Texto("Un ambiente de funebria recorre el ambiente, \nun palco al fondo junto a una mesa con relicarios y un gran arte en vidrio al fondo. \nEs una pequeña iglesia, completamente sola. En la mitad, un ataúd vacío, con una nota.");
            Boton("Continuar");
            Texto("“Abre las cajas. \nToma las piezas recolectadas y reconstruye el contenido de las cajas”");

            List<string> opciones = new List<string> { "Abrir las cajas", "Intentar salir", "Volver por el camino" };
            bool cuerpoArmado = false;

            while (cuerpoArmado == false)
            {
                string eleccion = Menu(opciones);

                if (eleccion == "Abrir las cajas")
                {
                    Texto("“Son piezas humanas…\nEs mi madre… O lo que queda de ella… ¿¡Mamá, qué te hicieron!?”\nGritas mientras caen las lágrimas de espanto de tu rostro y contienes las ganas de vomitar.");

                    Boton("Continuar");
                    opciones.Add("Armar el cuerpo de tu madre muerta");
                }
                else if (eleccion == "Intentar salir" || eleccion == "Volver por el camino")
                {
                    Texto("No podrás dejar este lugar hasta reconstruir el contenido de las cajas.");
                    Boton("Continuar");
                }
                else if (eleccion == "Armar el cuerpo de tu madre muerta")
                {
                    Texto("Atas paso a paso todo; la cabeza y cuello al torso, \nlos brazos a los hombros, \nlas piernas a la cadera \ny el resto del cuerpo poco a poco. \nLa última pieza es la mano derecha, y mientras sigues limpiando tus lágrimas… \nVes que algo oculta el puño de tu madre.");
                    cuerpoArmado = true;
                }
            }
            List<string> nota = new List<string> { "Leer nota" };
            Menu(nota);
            Texto("“Hijo, espero puedas leer esto. \nHe sido secuestrada, me han torturado no sé por cuánto tiempo y no lo entiendo. \nNo entiendo qué pude haber hecho distinto para que esto no sucediera. \nEncontré esto en el cuarto en el que me tienen para poder hacerte llegar mis palabras; \nhijo, fuiste mi luz y mi razón de seguir, \ny espero te conviertas en el piloto que luchaste por ser, quizás nos encontremos en los cielos. \nAspiro llegar allá para verte. \nTe amo, mi niño”.");
            Boton("Continuar");
            Texto("Quedas postrado en el piso, llorando y sosteniendo la mano de tu madre y su nota final. \nMiras perplejo tus alrededores y ves que entre las herramientas, hay también un arma de fuego. \nSe abre una puerta crujiendo cerca de ti.");

            List<string> final = new List<string> { "Salir", "Suicidarte" };
            Menu(final);
            Fin();
        }

        // NARRATIVA 2

        public void PuertaCristal()
        {
            Divisor();
            Texto("El cuarto es del mismo material de la puerta por la que acabas de pasar.\nLas paredes son vitrinas incrustadas. En cada vitrina hay objetos de tu vida con etiquetas que tienen la letra de tu madre. Solo una de las vitrinas tiene una luz distintiva, que señala la caja que debes tomar.");

            List<string> opciones = new List<string> { "Acercarse a las vitrinas", "Tomar caja de la vitrina" };
            while (opciones.Count > 0)
            {
                string eleccion = Menu(opciones);

                if (eleccion == "Acercarse a las vitrinas")
                {
                    // aRRAY OBJ

                    string[] objetos =
                    {
                        // Objeto 1
                        "Un chupete mordido. La etiqueta dice \n“1 año. Mordeduras, como las que hace cada vez que tiene hambre. Es violento, un niño violento”.",
                        // Objeto 2
                        "Unas llaves de juguete, etiquetadas como \n“3 años. ¿Planea encerrarme?”",
                        // Objeto 3
                        "Un dibujo de niño pequeño con una mujer y un niño a su lado. \n“5 años. ¿Quiénes son esas personas?”",
                        // Objeto 4
                        "Una bolsa de crayones, pinturas y lápices de color rojo. \n“7 años. Armas. Reunidas como el color de mi sangre.”"
                    };

                    string[] botones = { "Ver siguiente objeto", "Ver siguiente objeto", "Ver siguiente objeto", "Continuar" };
                    LeerPaginas(objetos, botones);
                }
                else if (eleccion == "Tomar caja de la vitrina")
                {
                    Texto("Ya no te sorprende el peso, el olor y el frío de la caja. \nSientes una presión en tu pecho y observas la única puerta que queda llena de retazos; telas aguamarinas, guantes de nitrilo y plásticos con jeringas.");
                    Boton("Continuar");
                }
            }
        }

        public void PuertaInsonorizada()
        {

            Divisor();
            Texto("El ruido que se ocasiona constantemente en tus oídos por la presión, se esfuma de repente al entrar a la habitación. \nUna única luz cenital alumbra la siguiente caja; encima tiene una grabadora con audios listos para escuchar.");


            List<string> opciones = new List<string> { "Escuchar grabación 1", "Tomar caja" };
            while (opciones.Count > 0)
            {
                string eleccion = Menu(opciones);

                if (eleccion == "Escuchar grabación 1")
                {
                    string[] grabaciones =
                    {
                        // Grabación 1
                        "“1… 2… 3… ¿Sonido? Sonido…\nEste es el caso 778911. Paciente: Denis Welsh. Edad: 40 años. Soltera, madre de hijo único; “Pat” como le dice la paciente. \nPrimera sesión: La paciente llega sola con claras marcas de estrés y rasguños por el cuerpo. \nRefiere que las marcas las ocasiona su hijo, Patrick Welsh, afirma que el joven le quema la piel con cigarrillos, la encierra en su cuarto y esconde la comida para que no pueda comer. \nLa paciente comenta que “Desde que nació… Él nació queriendo lastimarme” mientras llora.\nNota aparte: No pude evitar notar que sus declaraciones son como si estuviera leyendo y recitando un texto pre-escrito, y deja de llorar con facilidad, como si fingiera las lágrimas. \nFin de la primera sesión”.",
                        // Grabación 2
                        "“Caso 778911. \nNota extra: Recibí registros médicos de Patrick. \nHospitalizado a los 3 y 6 años por desnutrición. A los 8 años, fractura de muñeca con señales de forcejeo. A los 11, quemaduras en la espalda. \nSin seguimiento médico porque su tutora legal no autorizó los procedimientos y ordenó que se le diera de alta al niño. \nFin de la nota.”",
                        // Grabación 3
                        "“Caso 778911-B.\nPatrick Welsh, relacionado con el caso 778911, vino el día de hoy. \nMe contó del armario debajo de la escalera, de cómo su madre cree que al encerrarlo allí logra “protegerse de Pat”. \nPatrick trajo consigo notas de su madre en las que se refiere a él; “es un monstruo, nació para destruirme, tengo que castigarlo antes de que él lo haga conmigo”. \nTambién una foto perturbadora; Patrick bebé junto a un charco de sangre que salía de ciertas heridas de Denis, para tener pruebas del maltrato de su hijo ella se autoinflige daño.\nAl irse Patrick, me di cuenta que Denis no miente del todo. El problema es que en la mente de Denis, cada vez que le hace daño a Patrick, siente que ella es la víctima. \nFin de la nota.”",
                        // Grabación 4
                        "“Caso 778911. \nInforme final y diagnóstico.\nDenis Welsh no volvió a consulta, tampoco contesta su teléfono.\nEn nuestra última sesión, Denis me dijo que si Pat intentaba desarmarla, ella se escondería donde él nunca pudiera buscar. Pensé que era una metáfora.\nLa policía encontró en la casa a Patrick, encerrado debajo del armario. No recuerda nada, no sabe quién es ella, ni quién es él.\n\nNo sé si alguien va a escuchar esto. \nSi eres tú, Pat: no la busques. Hay cosas que están mejor desarmadas.\n\nFin de la grabación.”"
                    };

                    string[] botones = { "Escuchar grabación 2", "Escuchar grabación 3", "Escuchar grabación 4", "Continuar" };
                     LeerPaginas(grabaciones, botones);
                }

                else if (eleccion == "Tomar caja")
                {

                    Texto("Tomas una siguiente caja, la sensación es la misma que las anteriores. \nSolo queda una puerta frente a ti, es una puerta de retazos; telas aguamarinas, guantes de nitrilo y plásticos con jeringas.");
                    Boton("Continuar");
                }
            }
        }

        public void SalaQuirurgica()
        {
            Divisor();
            Texto("Al abrir la puerta, un olor antiséptico abunda en el lugar. \nLa luz titila sobre las paredes verdes mezcladas con blanco. \nHay elementos de hospital en varios puntos de la habitación; frente a ti, una camilla con delimitaciones en marcador. Calzan perfecto con las dimensiones de las cajas que has recogido. Y una nota en la cabecera.");
            Boton("Continuar");
            Texto("“Abre las cajas. Toma las piezas recolectadas y reconstruye el contenido de las cajas”");


            List<string> opciones = new List<string> { "Abrir las cajas", "Intentar salir", "Volver por el camino" };
            bool cuerpoArmado = false;

            while (cuerpoArmado == false)
            {
                string eleccion = Menu(opciones);

                if (eleccion == "Abrir las cajas")
                {
                    Texto("“Son piezas humanas…\nEs mi madre… Así que aquí estabas”");
                    Boton("Continuar");
                    opciones.Add("Armar el cuerpo de tu madre muerta");
                }
                else if (eleccion == "Intentar salir" || eleccion == "Volver por el camino")
                {
                    Texto("No podrás dejar este lugar hasta reconstruir el contenido de las cajas.");
                    Boton("Continuar");
                }
                else if (eleccion == "Armar el cuerpo de tu madre muerta")
                {
                    Texto("Con herramientas de suturar, hilas cada pedazo del cuerpo, empezando desde los pies uniéndolos a sus piernas y siguiendo por la cadera, los brazos, manos y cuello, dejando la cabeza de últimas. Progresivamente, ves marcas en el torso de tu madre que dicen un mensaje, limpias el cuerpo con desespero.");
                    cuerpoArmado = true;
                }
            }

            List<string> marcas = new List<string> { "Leer marcas" };
            Menu(marcas);
            Texto("“Desahoga tu dolor en este cuerpo vacío”.");
            Boton("Continuar");
            Texto("Con toda la rabia del abuso que sufriste por años a manos de tu madre, decides hacer caso y desahogarte por completo.\nDespedazas su cuerpo con llanto de rabia, quemas sus manos como ella hacía contigo; estás desenfrenado de ira. Cubierto en sangre, tomas la cabeza y quedas frente a frente con el rostro de tu trauma.");
            Boton("Gritar al cadáver");
            Texto("“¿Por qué tenías que hacerme tanto daño? ¡¿Por qué aún muerta me sigues dando tantos dolores de cabeza, debo seguir persiguiéndote a ti y a tu cariño?! ¡NUNCA TE NECESITÉ, TU MUERTE ES AHORA MI ALIVIO!”");
            Boton("Continuar");
            Texto("“Adiós, madre”");

            List<string> final = new List<string> { "Salir" };
            Menu(final);
            Fin();
        }
    }
}