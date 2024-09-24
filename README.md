
---

# **ML-Agent Reinforcement Learning** 🧠

Este proyecto utiliza **ML-Agents** de Unity para implementar un agente que aprende a moverse en un entorno 3D utilizando aprendizaje por refuerzo.

---

## **Requisitos previos** ✅

Antes de comenzar, asegúrate de tener instalados los siguientes requisitos en tu máquina:

- [Unity Hub](https://unity.com/download) (versión 2020.3 o superior recomendada)
- [Python 3.8 - 3.10](https://www.python.org/downloads/)
- [ML-Agents Toolkit](https://github.com/Unity-Technologies/ml-agents) instalado

---

## **Creación del proyecto en UnityHub** 🛠️

1. Abre **Unity Hub** y crea un nuevo proyecto (**New Project**).
   - Asegúrate de que tienes la versión correcta de Unity instalada.
   - Dale un nombre adecuado a tu proyecto.
   
   ![Unity Hub](https://github.com/user-attachments/assets/2a956230-bdbd-4571-9d4d-de816bbb26c7)

2. Una vez creado el proyecto, abre la carpeta del proyecto en Unity.
   
   ![Carpeta del Proyecto](https://github.com/user-attachments/assets/94f83ce6-e5ec-4cf1-a305-6c76c81cb61e)

---

3. Verificar instalacion de python

```bash
py -0
```

## **Instalación de ML-Agents** 🤖

1. Abre una terminal en la carpeta de tu proyecto y asegúrate de estar en la ruta correcta.
   ![Terminal](https://github.com/user-attachments/assets/da46aa30-3556-41d1-aa4e-a4ec6eea34d4)

2. Crea un entorno virtual con la versión de Python adecuada (3.8 - 3.10). Para este ejemplo, utilizamos Python 3.8:
   ```bash
   py -3.8 -m venv venv
   ```

3. Activa el entorno virtual. Usa `\` para sistemas Windows:
   ```bash
   venv\Scripts\activate
   ```

4. Si todo funcionó bien, deberías ver algo como esto en tu terminal:
   ```bash
   (venv) C:\users\TuUsuario\Lugardondetienestuproyecto
   ```

5. Instalar todas las dependencias:
   ```bash
   pip install -r requirements.txt
   ```
6. Actualizar pip

   ```bash
   pip install --upgrade pip
   ```

7. Verifica que ML-Agents se instaló correctamente ejecutando el siguiente comando:

   ```bash
   mlagents-learn --help
   ```




## **Entrenamiento del agente** 🏋️‍♂️

1. En Unity, selecciona el **Componente Agent** y asegúrate de que la opción `Behavior Type` esté configurada como **Default** para el entrenamiento.
2. Verifica que Unity está conectado a ML-Agents y que tu archivo YAML está listo.

3. Desde la terminal, ejecuta el comando para iniciar el entrenamiento del agente:
   ```bash
   mlagents-learn --run-id <nombre_de_experimento>
   ```

4. Una vez iniciado el entorno, selecciona **Play** en Unity para comenzar el entrenamiento.

---

## **Comandos Útiles** 🧰

- Verificar que ML-Agents está funcionando correctamente:
   ```bash
   mlagents-learn --help
   ```

- Visualizar los resultados de entrenamiento con **TensorBoard**:
   ```bash
   tensorboard --logdir results
   ```

- Para detener el entrenamiento en cualquier momento:
   ```bash
   Ctrl + C
   ```
- Para Revisar si hay algun error entre dependencias
  ```bash
   pip check
   ```
- Para mostrar dependencias instaladas
 ```bash
   pip freeze

   ```
---

## **Probar el agente entrenado** 🎮

1. Una vez completado el entrenamiento, cambia el comportamiento del agente a `Inference` en el componente `Behavior Parameters`.
2. Ejecuta la escena en Unity para ver cómo el agente se comporta utilizando el modelo entrenado.

---

## **Posibles Errores y Soluciones** 🛠️

### 1. **Error**: `mlagents-learn` no es reconocido como comando.
   - **Solución**: Asegúrate de que `mlagents` esté instalado correctamente:
     ```bash
     pip install mlagents
     ```

### 2. **Error**: `IndexOutOfRangeException` en `Heuristic`
   - **Solución**: Verifica que el número de acciones en el método `Heuristic` coincida con los parámetros en `Behavior Parameters`.

### 3. **Error**: `TensorFlow` no está instalado.
   - **Solución**: Instala TensorFlow si ves errores relacionados con esta librería:
     ```bash
     pip install tensorflow==2.7.0
     ```

### 4. **Error**: `Python Package Not Found` en Unity.
   - **Solución**: Asegúrate de que Unity está configurado para usar la ruta correcta de Python en **Edit > Preferences > External Tools**.

### 5. **Error**: `grpc_tools` no está instalado.
   - **Solución**: Instala la librería faltante:
     ```bash
     pip install grpcio-tools
     ```

---

## **Referencias y Recursos** 📚

- [Unity ML-Agents Toolkit Documentation](https://github.com/Unity-Technologies/ml-agents)
- [ML-Agents Python API](https://github.com/Unity-Technologies/ml-agents/tree/main/ml-agents)
- [Instalación de ML-Agents](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Installation.md)

---

¡Gracias por revisar este proyecto! Si tienes alguna duda o encuentras problemas, por favor abre un **issue** en este repositorio.

---
