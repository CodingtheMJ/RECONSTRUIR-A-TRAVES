using System;
using System.Collections.Generic;


namespace ReconstruirATraves
{
    class PuertaMetal
    {
        Juego juego;

        public PuertaMetal(Juego juego)
        {
            this.juego = juego;
        }

        public void Entrar()
        {
            juego.Divisor();
            juego.Texto("Un ambiente de oficina domina el cuarto, lleno de archivadores, mesas metálicas y una unidad de colores apagados en blanco, negro y gris. Una máquina de escribir, redacta por sí sola de manera mecánica, se escucha el timbre del cilindro al acabar una frase y el resorte que se devuelve sin que nadie lo toque. Junto a la máquina, un gran aviso en rojo y una caja en la silla de oficina.");

            List<string> opciones = new List<string> { "Inspeccionar aviso", "Recoger caja", "Inspeccionar contenido escrito de la máquina" };
            while (opciones.Count > 0)
            {
                string eleccion = juego.Menu(opciones);

                if (eleccion == "Inspeccionar aviso")
                {
                    juego.Texto("“Si quieres salir, no puedes dejar ninguna pista atrás”.");
                    juego.Boton("Continuar");
                }
                else if (eleccion == "Recoger caja")
                {
                    juego.Texto("La caja es ligeramente pesada. Es de cartón y está sellada pero la sientes un poco fría al tomarla.");
                    juego.Boton("Continuar");
                }
                else if (eleccion == "Inspeccionar contenido escrito de la máquina")
                {
                    juego.Texto("Es un certificado de nacimiento que tiene resaltado el nombre del recién nacido “Patrick Welsh” \ny de su madre “Denis Welsh”. Los datos del padre están vacíos.");
                    juego.Boton("Continuar");
                }
            }

            List<string> puertas = new List<string> { "Abrir puerta de cristal", "Abrir puerta de espuma" };
            juego.Texto("Al fondo del cuarto, otras dos nuevas puertas. \nUna es de cristal esmerilado, y la otra de espuma negra con pequeños triángulos sobresalientes hacia ti.");

            while (puertas.Count > 0)
            {
                string eleccion = juego.Menu(puertas);

                if (eleccion == "Abrir puerta de cristal")
                {
                    juego.PuertaCristal();
                }
                else if (eleccion == "Abrir puerta de espuma")
                {
                    juego.PuertaInsonorizada();
                }

                juego.Divisor();
                juego.Texto("Has vuelto a la habitación anterior.");
            }

            List<string> retazos = new List<string> { "Abrir puerta de retazos" };
            juego.Menu(retazos);
            juego.SalaQuirurgica();
        }
    }
}