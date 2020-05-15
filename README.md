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
Actualizado el sprite de background -Javier
Actualizado el sprite de la lava, ahora es una animación -Javier

//Cambios hechos el 25 de abril
Arreglado el input de la interfaz y los controles
Arreglado anclas del menu e imagen de fondo de tenia - Samuel
Tutorial Finalizado y arreglado a la perfección -Samuel
Creado Boton reintentar al morir - Samuel
Corregido Anclas y Background escena Fin -Samuel
HE DESCUBIERTO QUE HAY PROBLEMAS AL CAMBIAR DE ESCENAS IN GAME -SAMUEL

//Cambios hechos el 26 de abril
Añadidas las animaciones: Idle, Run y Shoot
Implementadas animaciones de mecánicas -Javier
Insertadas en el menu de tabulación -Javier

//Cambios hechos el 27 de abril
Ahora la pastilla tiene las animaciones asignadas.
Animaciones añadidas: ataque a melee.
Cambiado el cambio de pastilla.
Solucionado un error del WallJump relacionado con el cambio de pastilla.
Cambiada la imagen de los controles.
Ahora se puede acceder a los controles desde el menú.
Habilitado el botón de Opciones del menú.
Creadas las plataformas estáticas -Javier
Implementada la zona inicial modo tutorial -Javier 

//Cambios hechos el 1 de mayo
Creada la sala del Gran Coágulo - Miguel
Purgado un Find del código, ahora no da problemas al morir el jugador - Miguel
Añadida Sorting Layer para el background y el player - Miguel
GranCoagulo apartado del resto de desarrollo para poder trabajar de forma más comoda - Miguel
Ahora el GranCoágulo puede usar Disparo De Sangre - Miguel

//Cambios hechos el 2 de mayo
Comenzado el desarrollo de las oleadas de Adds del Gran Coágulo - Miguel
Comenzada a crear la sala de la tenia boss y ajustar el colesterol - Daniel


//Cambios hechos el 3 de mayo
Ahora el tutorial solo se aplica en Area_Hito - Samuel
Creado prototipo Oleada Dañiña -Samuel
Creado sprites OleadaDañina - Samuel
Ahora el Gran Coágulo spawnea los adds correctamente y te mata si no los matas lo suficientemente rápido - Miguel
"Finalizado" ataque oleada Dañina - Samuel
Ahora si quieres poner OleadaDañina en la pared de la derecha pon true el bool Rotate del GO- Samuel
Creada la base de un par de habilidades de la tenia Bossn - Daniel

//Cambios hechos el 5 de mayo
Áñadido el código para implementar todos los FX y las pistas base -Javier

//Cambios hechos el 6 de mayo
Terminado el desarrollo de la oleada dañina - Samuel
JUntado el progreso del Gran Coágulo - Miguel
Terminado de ajustar los ataques de la Tenia , ya se puede dar como completada a nivel de mecanicas / habilidades - Daniel 
Arreglado el deshabilitado de colliders con las plataformas móviles -Javier
Implementado todo el codigo para los SFX y la música de fondo -Javier
cambiado el color de la lava por verde -Javier

//Cambios hechos el 7 de mayo
Escena tutorial al terminada al 50% - Samuel
La tenia ahora es un prefab - Daniel
Sala de la tenia terminada,con la respectiva tenia y las plataformas ajustadas (su posicion y movimiento) - Daniel

//Cambios hechos el 8 de mayo
Añadida shorting layer Decorations --Samuel
Escena tutorial terminada al 100% --Samuel
Menú modificado: Letras cambiadas
				Ahora hay un nuevo boton de elegir niveles -Samuel
Ahora cuando pegas a un enemigo se nota visualmente que le has hecho daño --Samuel
Reemplazado el prefab de plataforma movil -Javier
Implementada la bajada de plataformas móviles -Javier

//Cambios hechos el 10 de mayo
Se ha ajustado el nivel 1, se ha cambiado el tille pallete de la lava, se han modificado enemigos, el mapa etc. - Javi y Nico
Se ha añadido un Script que atrae los glóbulos rojos y blancos

//Cambios hechos el 11 de mayo
El tutorial ya está acabado con los diagramas y la interfaz correcta --Samuel
Arregladas las plataformas del Gran Coágulo - Miguel
Arreglados los problemas del colesterol - Miguel
Ahora las balas enemigas no son destruidas por los ataques del jugador - Miguel
Añadidas las barras para regular la música de fondo, los efectos de sonido y el volumen general -Javier
Modificado prefab de player que ahora contiene tambien cosas de sonido -Javier

//Cambios hechos el 12 de mayo
Comenzado el desarrollo de la acumulación de energía del Gran Coágulo - Miguel

//Cambios hechos el 13 de mayo
Ahora los coágulos sueltan glóbulos rojos - Miguel
Actualizado el input a su última versión - Miguel
Añadido el Input UI/Move - Miguel

//Cambios hechos el 14 de mayo
Deshabilitado el SpriteRenderer del ataque a melee - Miguel
Añadido funcionamiento Boton elegir nivel- Samuel
Ajustes nivel 1 -Samuel
Canvas arreglado Nivel1, tutorial y menu - Samuel

//Cambios hechos el 15 de mayo
Arreglado mapa de lava, no tenía colisiones ni hacía daño
Ajustado radio del atractor de monedas, se ha disminuido
Actualizado el input - Miguel