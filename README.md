
# ML-Agent Reinforcement Learning

Este proyecto utiliza **ML-Agents** de Unity para implementar un agente que aprende a moverse en un entorno 3D utilizando aprendizaje por refuerzo.

## Requisitos previos

Antes de comenzar, asegúrate de tener instalados los siguientes requisitos en tu máquina:

- [Unity Hub](https://unity.com/download) (versión 2020.3 o superior recomendada)
- [Python 3.8 - 3.10](https://www.python.org/downloads/)
- [ML-Agents Toolkit](https://github.com/Unity-Technologies/ml-agents) instalado

## Creación del proyecto en UnityHub
Si ya haz instalado correctamente las versiones del editor de Unity procede a Crear Proyecto "New Project"
![Unity Hub 3 9 1 21_09_2024 1_29_45 p  m](https://github.com/user-attachments/assets/2a956230-bdbd-4571-9d4d-de816bbb26c7)



## Instalación de ML-Agents
1. Abre la carpeta de tu proyecto de Unity
![image](https://github.com/user-attachments/assets/94f83ce6-e5ec-4cf1-a305-6c76c81cb61e)


2. Abre una terminal cambiando la ruta y presionando enter

![image](https://github.com/user-attachments/assets/da46aa30-3556-41d1-aa4e-a4ec6eea34d4)

3. Crea un entorno de desarrollo con la version de python entre 3.8 y 3.10 para el ejemplo es 3.8
   ```bash
   py -3.8 -m venv Nombre_de_tu_entorno
   ```
4. Activa el entorno de desarrollo utiliza estas "\" no estas "/".
   ```bash
   Nombre_de_tu_entorno\Scripts\activate
   ```
   
5. Si funciono la activación deveria aparecer asi
      ```bash
   (Nombre_de_tu_entorno) C:\users\TuUsuario\Lugardondetienestuproyecto
   ```
6. Instala el paquete `mlagents` y las dependencias
   
   ```bash
   pip install mlagents
   ```
8. Instala el paquete `torch` y las dependencias

   ```bash
   pip install torch torchvision torchaudio
   ```

9. Verifica que `mlagents` se ha instalado correctamente:
    
   ```bash
   mlagents-learn --help
   ```

## Entrenamiento del agente

1. En Unity, selecciona el **Componente Agent** y asegúrate de que la opción `Behavior Type` esté configurada como `Default` para el entrenamiento.
2. Asegúrate de que el archivo YAML está listo y que Unity está conectado al paquete **ML-Agents**.

3. En la terminal, ejecuta el siguiente comando desde el directorio donde guardaste el archivo de configuración YAML:
   ```bash
   mlagents-learn config/trainer_config.yaml --run-id <nombre_de_experimento>
   ```

4. Una vez que el entorno se haya iniciado correctamente, selecciona **Play** en Unity para comenzar el entrenamiento del agente.

## Comandos Útiles

- Para verificar que `mlagents-learn` está funcionando:
  ```bash
  mlagents-learn --help
  ```

- Para visualizar los resultados de entrenamiento:
  ```bash
  tensorboard --logdir results
  ```

- Para detener el entrenamiento:
  ```bash
  Ctrl + C
  ```

## Probar el agente entrenado

1. Una vez completado el entrenamiento, cambia el comportamiento del agente a `Inference` en el componente `Behavior Parameters`.
2. Ejecuta la escena en Unity para ver cómo el agente se comporta utilizando el modelo entrenado.

## Referencias

- [Unity ML-Agents Toolkit Documentation](https://github.com/Unity-Technologies/ml-agents)
- [ML-Agents Python API](https://github.com/Unity-Technologies/ml-agents/tree/main/ml-agents)
- [Instalación de ML-Agents](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Installation.md)

---

¡Gracias por revisar este proyecto! Si tienes alguna duda o encuentras problemas, por favor abre un **issue** en este repositorio.
```
