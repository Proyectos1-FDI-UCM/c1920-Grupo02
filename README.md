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