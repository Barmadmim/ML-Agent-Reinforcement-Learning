Escenario: Juego Simple de Grid 3x3
Imaginemos un entorno de 3x3 como en el ejemplo anterior. El agente se mueve en una cuadrícula, tratando de llegar a un objetivo (celda 8) desde una posición inicial (celda 0). El agente recibe recompensas cuando llega al objetivo (+10) y penalizaciones (-1) por moverse y -5 si se sale del grid.

Pero esta vez no vamos a usar una tabla Q, sino que el agente utilizará una red neuronal profunda (Deep Q-Network) para predecir los valores Q de las acciones.

1. Definición de Estados y Acciones:
Estados: Cada celda en el grid representa un estado. Tenemos 9 estados (numerados de 0 a 8), pero no usaremos una tabla Q para cada estado. En cambio, introduciremos los estados como vectores de entrada en la red neuronal.

Por ejemplo, el estado 0 (posición inicial) se representa como un vector:

𝑠
0
=
[
1
,
0
,
0
,
0
,
0
,
0
,
0
,
0
,
0
]
s 
0
​
 =[1,0,0,0,0,0,0,0,0]
El estado 1 será:

𝑠
1
=
[
0
,
1
,
0
,
0
,
0
,
0
,
0
,
0
,
0
]
s 
1
​
 =[0,1,0,0,0,0,0,0,0]
Y así sucesivamente.

Acciones: El agente puede moverse en 4 direcciones:

Arriba (↑), Abajo (↓), Izquierda (←), Derecha (→).
2. Recompensas:
Recompensa de +10 al llegar al estado objetivo (celda 8).
Penalización de -1 por moverse.
Penalización de -5 si se sale del grid.
3. Estructura de la Red Neuronal (Deep Q-Network):
La Deep Q-Network (DQN) será una red neuronal simple con:

Entrada: El estado del entorno, representado como un vector de 9 dimensiones.
Capas ocultas: Capas densas con activaciones ReLU.
Salida: Un vector de 4 dimensiones, que representa el valor Q estimado para cada una de las 4 acciones posibles (arriba, abajo, izquierda, derecha).
Red DQN:
Entrada: Vector de tamaño 9 (representa el estado).
Capa oculta 1: 64 neuronas, activación ReLU.
Capa oculta 2: 64 neuronas, activación ReLU.
Capa de salida: 4 neuronas, sin activación. Cada neurona da el valor Q para una acción posible (arriba, abajo, izquierda, derecha).
Dimensi
o
ˊ
n de entrada
→
Capa oculta 1
→
Capa oculta 2
→
Capa de salida
Dimensi 
o
ˊ
 n de entrada→Capa oculta 1→Capa oculta 2→Capa de salida
9
→
64
→
64
→
4
9→64→64→4
4. Entrenamiento del DQN:
Datos de entrenamiento:
Input: El estado actual (como vector de 9 valores, uno por cada celda del grid).
Output: El valor Q para cada acción posible en ese estado.
El algoritmo aprende a ajustar los pesos de la red para predecir correctamente los valores Q, utilizando la fórmula de actualización del Q-Learning:

𝑄
(
𝑠
,
𝑎
)
←
𝑄
(
𝑠
,
𝑎
)
+
𝛼
(
𝑟
+
𝛾
max
⁡
𝑎
′
𝑄
(
𝑠
′
,
𝑎
′
)
−
𝑄
(
𝑠
,
𝑎
)
)
Q(s,a)←Q(s,a)+α(r+γ 
a 
′
 
max
​
 Q(s 
′
 ,a 
′
 )−Q(s,a))
Donde:

s: Estado actual.
a: Acción tomada.
r: Recompensa obtenida.
s': Nuevo estado.
𝛾
γ: Factor de descuento.
𝛼
α: Tasa de aprendizaje.
Ejemplo concreto:
Estado actual: El agente está en la celda 0, representado por el vector:
𝑠
0
=
[
1
,
0
,
0
,
0
,
0
,
0
,
0
,
0
,
0
]
s 
0
​
 =[1,0,0,0,0,0,0,0,0]
Acciones posibles: El agente puede moverse en 4 direcciones.

La red predice los valores Q para cada acción. Supongamos que, al principio, los valores Q son los siguientes:

𝑄
(
𝑠
0
)
=
[
−
0.5
0.2
0.1
0.4
]
Q(s 
0
​
 )=[ 
−0.5
​
  
0.2
​
  
0.1
​
  
0.4
​
 ]
Donde:

Q(s_0, arriba) = -0.5
Q(s_0, abajo) = 0.2
Q(s_0, izquierda) = 0.1
Q(s_0, derecha) = 0.4
Entonces, el agente elige la acción con el valor Q más alto (derecha, con 0.4).

Nueva acción: El agente se mueve hacia la derecha (acción "derecha"). Ahora está en el estado 1 (celda 1).

Recompensa: Por moverse, el agente recibe una penalización de -1.

Actualización de Q: La red neuronal se actualiza de acuerdo a la fórmula de Q-Learning:

𝑄
(
𝑠
0
,
derecha
)
←
𝑄
(
𝑠
0
,
derecha
)
+
𝛼
(
𝑟
+
𝛾
max
⁡
𝑎
′
𝑄
(
𝑠
1
,
𝑎
′
)
−
𝑄
(
𝑠
0
,
derecha
)
)
Q(s 
0
​
 ,derecha)←Q(s 
0
​
 ,derecha)+α(r+γ 
a 
′
 
max
​
 Q(s 
1
​
 ,a 
′
 )−Q(s 
0
​
 ,derecha))
Supongamos:

𝛼
=
0.1
α=0.1
𝛾
=
0.9
γ=0.9
𝑟
=
−
1
r=−1
La red predice los valores Q para el estado 
𝑠
1
s 
1
​
  (celda 1), que inicialmente son:

𝑄
(
𝑠
1
)
=
[
0.1
−
0.2
0.3
0.5
]
Q(s 
1
​
 )=[ 
0.1
​
  
−0.2
​
  
0.3
​
  
0.5
​
 ]
El valor máximo para 
𝑄
(
𝑠
1
)
Q(s 
1
​
 ) es 
0.5
0.5 (acción "derecha").
Ahora actualizamos el valor 
𝑄
(
𝑠
0
,
derecha
)
Q(s 
0
​
 ,derecha):

𝑄
(
𝑠
0
,
derecha
)
=
0.4
+
0.1
×
(
−
1
+
0.9
×
0.5
−
0.4
)
Q(s 
0
​
 ,derecha)=0.4+0.1×(−1+0.9×0.5−0.4)
Calculamos:

𝑄
(
𝑠
0
,
derecha
)
=
0.4
+
0.1
×
(
−
1
+
0.45
−
0.4
)
Q(s 
0
​
 ,derecha)=0.4+0.1×(−1+0.45−0.4)
𝑄
(
𝑠
0
,
derecha
)
=
0.4
+
0.1
×
(
−
0.95
)
Q(s 
0
​
 ,derecha)=0.4+0.1×(−0.95)
𝑄
(
𝑠
0
,
derecha
)
=
0.4
−
0.095
=
0.305
Q(s 
0
​
 ,derecha)=0.4−0.095=0.305
El nuevo valor de 
𝑄
(
𝑠
0
,
derecha
)
Q(s 
0
​
 ,derecha) es 0.305.

5. Repetición del proceso:
Este proceso de explorar el entorno, predecir valores Q, tomar acciones, recibir recompensas y actualizar la red se repite miles de veces. Con el tiempo, el agente aprende a tomar las mejores decisiones en cada estado para maximizar las recompensas a largo plazo.

6. Entrenamiento con experiencia replay:
Para estabilizar el entrenamiento, utilizamos una técnica llamada replay buffer:

Almacenamos las experiencias del agente (estado, acción, recompensa, nuevo estado) en una memoria.
Durante el entrenamiento, seleccionamos muestras aleatorias de esta memoria y las usamos para actualizar la red, en lugar de hacerlo en tiempo real.
Esto mejora la estabilidad y eficiencia del entrenamiento.

7. Salida de la red:
Cada vez que el agente se encuentra en un estado, la red neuronal toma ese estado como entrada y produce un vector de 4 valores Q (uno por cada acción posible). El agente elige la acción con el valor Q más alto.

Resumen del Proceso DQN:
Input: El estado actual del entorno (como un vector).
Red neuronal: Predice los valores Q para todas las acciones posibles desde ese estado.
Selección de acción: Elegimos la acción con el mayor valor Q.
Actualización: Después de tomar una acción y recibir una recompensa, se ajustan los pesos de la red para mejorar las predicciones futuras.
