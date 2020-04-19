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