El modelo de **Q-Learning** no utiliza redes neuronales tradicionales (con capas ocultas) en su forma básica. Sin embargo, se basa en una **tabla Q** (una matriz) que mapea cada estado a un valor Q para cada acción posible. Vamos a explicar esto con un ejemplo sencillo y, al final, haré una comparación con el **Deep Q-Learning** (DQN), que sí utiliza redes neuronales.

### Ejemplo: Q-Learning en un entorno simple

Supongamos que tenemos un agente que debe moverse en un entorno de 3x3 (un grid) para llegar a un objetivo y evitar una penalización. El agente puede moverse hacia arriba, abajo, izquierda y derecha.

#### 1. **Estados y Acciones**:
   - **Estados**: Cada celda del grid representa un estado. Supongamos que tenemos una matriz de 3x3, donde cada celda es un estado único. Numeramos los estados del 0 al 8.

     ```
     0  1  2
     3  4  5
     6  7  8
     ```

   - **Acciones**: El agente puede moverse en 4 direcciones:
     - `arriba` (↑), `abajo` (↓), `izquierda` (←), `derecha` (→).

#### 2. **Recompensas**:
   - El agente recibe una recompensa de +10 si llega al estado objetivo (celda 8) y una recompensa de -1 si se mueve a una celda normal.
   - Si el agente se sale del grid (por ejemplo, moviéndose hacia arriba desde la fila superior), recibe una penalización de -5.

#### 3. **Tabla Q (Matriz Q)**:
   La tabla Q es una matriz en la que las filas representan los **estados** y las columnas representan las **acciones**. Cada celda de esta matriz Q(s, a) representa el valor esperado de tomar la acción `a` en el estado `s`.

   - Matriz Q inicial (todos los valores empiezan en cero):

     | Estado | Arriba (↑) | Abajo (↓) | Izquierda (←) | Derecha (→) |
     |--------|------------|-----------|---------------|-------------|
     |   0    |     0      |     0     |       0       |      0      |
     |   1    |     0      |     0     |       0       |      0      |
     |   2    |     0      |     0     |       0       |      0      |
     |   3    |     0      |     0     |       0       |      0      |
     |   4    |     0      |     0     |       0       |      0      |
     |   5    |     0      |     0     |       0       |      0      |
     |   6    |     0      |     0     |       0       |      0      |
     |   7    |     0      |     0     |       0       |      0      |
     |   8    |     0      |     0     |       0       |      0      |

#### 4. **Algoritmo Q-Learning**:
Cada vez que el agente toma una acción desde un estado, actualiza el valor Q de esa acción utilizando la siguiente fórmula:

\[
Q(s, a) \leftarrow Q(s, a) + \alpha \left( r + \gamma \max_{a'} Q(s', a') - Q(s, a) \right)
\]

- **s**: El estado actual.
- **a**: La acción tomada en el estado actual.
- **s'**: El estado resultante después de tomar la acción.
- **r**: La recompensa recibida.
- \(\alpha\): Tasa de aprendizaje (qué tanto actualizamos el valor Q).
- \(\gamma\): Factor de descuento (qué tanto valoramos las recompensas futuras).
- \(\max_{a'} Q(s', a')\): El máximo valor Q posible en el nuevo estado.

### Ejemplo de actualización:

Supongamos que el agente está en el estado 0 (esquina superior izquierda) y decide moverse hacia la derecha. Esto lo lleva al estado 1.

1. Estado inicial: \( s = 0 \), Acción: \( a = \text{derecha} \), Recompensa: \( r = -1 \), Estado nuevo: \( s' = 1 \).
2. El valor Q actual es \( Q(0, \text{derecha}) = 0 \).
3. El valor máximo \( \max_{a'} Q(1, a') = 0 \) (pues todos los valores están inicializados en 0).
4. Supongamos que \( \alpha = 0.1 \) y \( \gamma = 0.9 \), entonces:

\[
Q(0, \text{derecha}) \leftarrow 0 + 0.1 \left( -1 + 0.9 \times 0 - 0 \right)
\]

Esto da:

\[
Q(0, \text{derecha}) = -0.1
\]

Ahora, la matriz Q se actualiza:

| Estado | Arriba (↑) | Abajo (↓) | Izquierda (←) | Derecha (→) |
|--------|------------|-----------|---------------|-------------|
|   0    |     0      |     0     |       0       |    **-0.1** |
|   1    |     0      |     0     |       0       |      0      |
|   2    |     0      |     0     |       0       |      0      |
|   3    |     0      |     0     |       0       |      0      |
|   4    |     0      |     0     |       0       |      0      |
|   5    |     0      |     0     |       0       |      0      |
|   6    |     0      |     0     |       0       |      0      |
|   7    |     0      |     0     |       0       |      0      |
|   8    |     0      |     0     |       0       |      0      |

### 5. **Repetición del proceso**:
El agente seguirá explorando el entorno, tomando acciones, recibiendo recompensas y actualizando la tabla Q. A medida que el agente explore más, los valores Q convergerán hacia la política óptima, es decir, las mejores acciones para cada estado.

---

### Extensión: **Deep Q-Learning (DQN)**

Cuando los espacios de estado son demasiado grandes (por ejemplo, juegos complejos o problemas con alta dimensionalidad), la tabla Q puede volverse impráctica. Aquí es donde entra el **Deep Q-Learning**, que utiliza una **red neuronal** para aproximar la función Q.

- **Entrada**: El estado del entorno (puede ser una imagen, una lista de variables, etc.).
- **Capas ocultas**: Las capas ocultas de una red neuronal procesan la entrada y aprenden características complejas.
- **Salida**: La red neuronal produce un valor Q para cada acción posible.

En lugar de tener una tabla Q explícita, el DQN entrena la red neuronal para que prediga los valores Q para cada acción, dado un estado.

#### Proceso de entrenamiento:

1. **Input**: Se introduce el estado actual del agente en la red neuronal.
2. **Predicción de Q-values**: La red predice los valores Q para todas las acciones posibles desde ese estado.
3. **Selección de acción**: Se elige la acción con el valor Q más alto o se explora una acción al azar.
4. **Actualización de la red**: La red se ajusta utilizando la diferencia entre la predicción actual y el valor Q objetivo (obtenido a través de la fórmula de Q-Learning).

### Ventajas de DQN:
- Maneja grandes espacios de estado, como juegos complejos (*Atari* o entornos 3D).
- La red neuronal puede generalizar entre estados similares, lo que mejora la eficiencia en entornos continuos o muy grandes.

### Conclusión

El Q-Learning tradicional usa una tabla para almacenar los valores Q, mientras que el Deep Q-Learning usa una red neuronal para aproximarlos. En ambos casos, el objetivo es que el agente aprenda una política que maximice las recompensas a largo plazo.
