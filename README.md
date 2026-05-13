### ProyectoCinematica_Fisica3D
# Parabolic Billar

#### Realizado por:

**Daniel García Navarro -->** @DanielGarciaFlorida

**Isabella McBrown García -->** @ismcga 

**Adrià Rodríguez Martínez -->** @Adria2304 

### Controles

- Mover el ratón: apuntar dirección del disparo.
- Clic izquierdo: lanzar la bola.

## Descripción del proyecto

Parabolic billar es un juego de billar cuyo objetivo principal ha sido aplicar conceptos de cinemática y físicas dentro de un entorno 3D.

La mecánica principal del proyecto consiste en lanzar bolas mediante un tiro parabólico calculado manualmente por código, combinándolo con físicas reales y un sistema de colisiones. 

El jugador puede apuntar utilizando el ratón y visualizar previamente la trayectoria que seguirá la bola antes de dispararla.

Además, el proyecto incorpora distintos elementos interactivos como puertas controladas mediante joints y mecánicas especiales aplicadas a determinadas bolas.

El juego utiliza una cámara en perspectiva cenital (vista de pájaro) para facilitar la visualización del tablero y la precisión del disparo

![](/README_Content/FotoVista.png)

## Funcionalidades Implementadas:

- Movimiento mediante tiro parabólico.
- Cálculo manual de trayectorias usando ecuaciones cinemáticas.
- Proyección visual de trayectoria.
- Sistema de colisiones.
- Uso de físicas reales mediante Rigidbody.
- Reinicio automático de bola al caer de la mesa.
- Uso de joints para puertas y desvíos.
- Sistema de disparo con dirección mediante ratón.
- UI básica de reinicio.

## Desarrollo del movimiento parabólico

La parte principal del proyecto ha sido el sistema de lanzamiento parabólico.

En lugar de depender únicamente de las físicas de Unity, se decidió calcular manualmente la posición de la bola durante el lanzamiento utilizando las fórmulas de cinemática:

![](/README_Content/FotoCodigo1.png)

Para ello, durante el lanzamiento la bola pasa a modo "kinematic", permitiendo moverla manualmente mediante código usando la posición calculada en cada frame.

![](/README_Content/FotoCodigo2.png)

## Sistema de colisiones

Uno de los principales problemas durante el desarrollo fue conseguir que la bola colisionara correctamente mientras se movía mediante cálculo manual.

Inicialmente, la bola atravesaba otras bolas o incluso la mesa debido a que al mover el objeto manualmente con transform.position no se estaban aplicando las físicas normales de Unity.

La solución implementada fue:

- Detectar colisiones usando Physics.OverlapSphere().
- Cambiar automáticamente el Rigidbody de kinematic a dinámico al detectar impacto.
- Aplicar una velocidad inicial equivalente para mantener continuidad en el movimiento.

![](/README_Content/FotoCodigo3.png)

## Proyección de trayectoria

La proyección de trayectoria se implementó utilizando un LineRenderer.

Antes de disparar, el sistema calcula múltiples posiciones futuras de la bola utilizando exactamente las mismas ecuaciones del tiro parabólico.

Estas posiciones se dibujan formando una línea visible para el jugador.

También se implementó un sistema para ocultar automáticamente la trayectoria una vez la bola ha sido lanzada.

![](/README_Content/FotoCodigo4.png)

## Control de disparo

El disparo se controla mediante el ratón usando el New Input System de Unity.

La dirección del disparo se obtiene calculando un vector desde el punto de spawn hasta la posición del ratón en el mundo.

Para convertir la posición del ratón desde pantalla al entorno 3D se utiliza un raycast desde la cámara.

![](/README_Content/FotoCodigo5.png)

La fuerza del disparo depende de la distancia entre el ratón y el punto de lanzamiento.

![](/README_Content/FotoCodigo6.png)

## Uso de Joints

El proyecto incorpora joints para crear puertas móviles y elementos en diferentes niveles que modifican la dirección de la bola.

Estos elementos permiten crear diferentes recorridos y añadir variedad al diseño de niveles.

![](/README_Content/FotoJoints.png)

## Sistema de reinicio

Cuando la bola cae fuera de la mesa se detecta la colisión con una superficie etiquetada como "Ground".

Ademas, tambien se puede ejecutar desde el boton de la UI para que el jugador reinicie cuando considere.

En ese momento:

- La bola actual se destruye.
- Se genera automáticamente una nueva bola.
- El jugador puede volver a disparar.



