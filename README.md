Tu archivo `README.md` se ve bastante completo, pero para hacerlo más atractivo y útil, podemos agregar algunas secciones adicionales y mejorar los estilos visuales. A continuación, te muestro una versión mejorada, con sugerencias de formato, imágenes, y algunos detalles más estructurados.

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

## **Instalación de ML-Agents** 🤖

1. Abre una terminal en la carpeta de tu proyecto y asegúrate de estar en la ruta correcta.
   ![Terminal](https://github.com/user-attachments/assets/da46aa30-3556-41d1-aa4e-a4ec6eea34d4)

2. Crea un entorno virtual con la versión de Python adecuada (3.8 - 3.10). Para este ejemplo, utilizamos Python 3.8:
   ```bash
   py -3.8 -m venv Nombre_de_tu_entorno
   ```

3. Activa el entorno virtual. Usa `\` para sistemas Windows:
   ```bash
   Nombre_de_tu_entorno\Scripts\activate
   ```

4. Si todo funcionó bien, deberías ver algo como esto en tu terminal:
   ```bash
   (Nombre_de_tu_entorno) C:\users\TuUsuario\Lugardondetienestuproyecto
   ```

5. Instala ML-Agents y las dependencias:
   ```bash
   pip install mlagents
   ```

6. También necesitas instalar PyTorch, una dependencia necesaria para entrenar el agente:
   ```bash
   pip install torch torchvision torchaudio
   ```

7. Verifica que ML-Agents se instaló correctamente ejecutando el siguiente comando:
   ```bash
   mlagents-learn --help
   ```

---

## **Configuración del YAML** 📄

Antes de iniciar el entrenamiento, necesitarás un archivo de configuración **YAML**. Crea una carpeta `config` dentro de tu proyecto de Unity y añade un archivo `trainer_config.yaml`.

Ejemplo de archivo `trainer_config.yaml`:

```yaml
behaviors:
  AgentController:
    trainer_type: ppo
    hyperparameters:
      batch_size: 64
      buffer_size: 2048
      learning_rate: 3.0e-4
      beta: 5.0e-4
      epsilon: 0.2
      lambd: 0.95
      num_epoch: 3
    network_settings:
      normalize: false
      hidden_units: 128
      num_layers: 2
    reward_signals:
      extrinsic:
        gamma: 0.99
        strength: 1.0
    max_steps: 500000
    time_horizon: 64
    summary_freq: 10000
```

---

## **Entrenamiento del agente** 🏋️‍♂️

1. En Unity, selecciona el **Componente Agent** y asegúrate de que la opción `Behavior Type` esté configurada como **Default** para el entrenamiento.
2. Verifica que Unity está conectado a ML-Agents y que tu archivo YAML está listo.

3. Desde la terminal, ejecuta el comando para iniciar el entrenamiento del agente:
   ```bash
   mlagents-learn config/trainer_config.yaml --run-id <nombre_de_experimento>
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
