Git Proyecto 1: Cambios

Acabado el esqueleto de los niveles 1 y 2, ambos jugables

Arreglado el Script de la Tenia, debería de funcionar como se espera

//Cambios hechos el día 7 de abril 

Añadido script PlataformaMovil, permite configurar gameObjects para que se muevan entre dos o más puntos
Creado un Sprite para las plataformas móviles

Modificado el script playerControllerWallJump para que funcione la tracción con las plataformas móviles

Creado prefab para plataformas móviles. Hay que modificar el número de puntos y su posición de forma local a ese gameObjects

//Cambios hechos el 8 de abril

Modificado PlayerConrollerWallJump para usar TryGetComponent en lugar de getcomponent por cuestiones de eficiencia

//Cambio hechos el 9 de abril

Cambiado el prefab del coágulo
Duplicados y cambiados varios scripts referentes al coágulo
Cambiado RecibeDanyo para que no precise spawnear un GameObject
Cambiado el script de realizar daño al enemigo para que realice un caso especial si se trata de un coágulo

//Cambios hecho el 10 de abril

Unificados Scripts BalaIz y BalaDcha en BalaSpeed
Arreglado bug que provocaba que las balas se audestruyeran nada más instanciarse
(había que cambiar las capas de colisión de DañoEnemigo y PlayerDeteccion para que no colisionaran)
Optimizado script BalaSpeed (antes de ser unificado, la velocidad de asignaba en el FixedUpdate, ahora se hace
en el Start porque con asignarla una vez basta)

//Cambios hechos el 13 de abril

Ahora el coágulo disminuye su velocidad de disparo considerablemente cuando pierde una de sus partes
Creado el prefab de Gran Coágulo (se precisa hablar con el grupo para especificar sus funciones)

Ahora cuando abres las opciones dentro del menú y le das a escape te vuelve al menú en vez de reanudar el juego con la interfaz puesta- Samuel
Ahora cuando cambias de nivel la interfaz actualiza correctamente las vidas - Samuel
Ahora cuando cambias la resolución del juego la interfaz no se ve modificada -Samuel

//Cambios hechos el 15 de abril

Ahora el Gran Coágulo puede disparar en todas las direcciones, falta limpiar los Scripts y determinar el comportamiento de las partes

//Cambios hechos el 17 de abril
Se ha creado un sistema para guardar y cargar partida - Nico
El sistema para guardar partida ahora guarda la vida, el nivel, el número de glóbulos rojos y blancos,
falta hacer que guarde el si tienes poderes o no y cual tenías cuando guardaste. - Nico
Creado script para cambiar color de camara - Javi
Creada la sala del boss -  Nico
Las plataformas ahora se atraviesan desde abajo
Los enemigos ya no pueden ser empujados por el jugador - Miguel
El fondo de pantalla cambia de color progresivamente cuando pierdes X vidas -Samuel y Javier

//Cambios hechos el 19 de abril 
Actualizado prefab plataforma móvil para que por defecto esté configurado para moverse entre dos puntos
Cambiado por completo el sistema de Input. Primera versión del Input Keyboard. Cambios acordes en varios scripts.

//Cambios hechos el 21 de abril
Añadido el input de GamePad. Ahora se puede jugar al proyecto con un mando de Xbox One. Debería de funcionar con otros tipos de GamePad.

//Cambios hechos el 22 de abril
Cambiado la interfaz del cambio de pastilla, Ahora no aparece hasta que coges la pastilla, y te dice cual llevas equipada -Samuel
Ahora las puertas indican la candidad de objetos a recoger para que se desbloqueen -Samuel
Añadido el input del numPad.
Cambiado el Script de PauseMenu, ahora se llama directamente al menú en vez de utilizar un bool.
WallJump Actualizado y pequeños cambios al resto del script PlayerControllerWallJump.

//Cambios hechos el 23 de abril
Ahora el dash tiene un cooldown configurable desde el editor

//Cambios hechos el 24 de abril
Añadido left click al input para que se pueda llamar desde la interfaz
Tutorial CASI acabado, falta pulsar TAB con la explicacion de las pastillas -Samuel
FINALLY el jugador se muere cuando se queda sin vidas - Samuel
Creado prototipo Controles pulsando tabulador - Samuel
Tutorial completado (aunque no finaliza por culpa de que el tabulador no funciona) -Samuel
Ahora las Tenias tienen un tiempo configurable de BreakTime, en el que no siguen al jugador después de colisionar con el.

//Cambios hechos el 25 de abril
Arreglado el input de la interfaz y los controles
Arreglado anclas del menu e imagen de fondo de tenia - Samuel
Tutorial Finalizado y arreglado a la perfección -Samuel
Creado Boton reintentar al morir - Samuel