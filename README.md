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