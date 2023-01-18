<%@ page language="VB" autoeventwireup="false" inherits="HTML5, App_Web_1ioibzdf" maintainScrollPositionOnPostBack="true" %>

<!DOCTYPE html>
<html>
    <head runat="server">
        <title></title>
        <style type="text/css" style="background-color: #FFFFFF">
            header
            {
                background-color: #000;
                color: #FFF;
            }
                      
            nav ul li
            {
                display: inline-block;
                cursor: pointer;
                margin-right: 25px;
            }
            
            
        </style>
    </head>
    <body>
        <header>Etiqueta header de HTML5</header>
        <nav>
            <ul>
                <li>Inicio</li>
                <li>Contacto</li>
                <li>Ayuda</li>
            </ul>
        </nav>
        <section>
            <article>
                Etiqueta article DE HTML5
                <audio controls="controls" loop="loop">
                    <source src="Y como es el - Marc Anthony.mp3" type="audio/mp3" />
                </audio>
                <input list="miLista" />
                <datalist id="miLista" runat="server">
                    <option value="codigoFacilito" />
                    <option value="codigo" />
                    <option value="Facilito" />
                </datalist>
                <details open>
                    <summary>Click para ver detalles</summary>
                    Aquí van los detalles
                </details>

                <p>
                Aquí está
                <figure>
                <figcaption>Bandera de México</figcaption>
                    <img src="Imagenes/logo_ver.png" />
                    
                </figure>
                un ejemplo
                </p>
                <p contenteditable"true" spellcheck="true">Hola mundo</p>
            </article>
            <aside>
                Etiqueta aside
            </aside>
        </section>
    </body>
</html>