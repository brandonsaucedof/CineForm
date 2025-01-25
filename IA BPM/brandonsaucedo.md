
# Proyecto de Inteligencia Artificial: Clasificador de Sentimientos en Tweets
- **Nombre**: [Brandon saucedo fariñas]() https://www.instagram.com/el_brandy_crow sigueme en instagram.

- **Universidad**: Universidad Privada Domingo Savio
- **Carrera**: Ingeniería de Sistemas

## 📌 Introducción
La música, como forma de expresión cultural, ha sido parte integral de la humanidad a lo largo de la historia. Desde los ritmos tribales hasta los géneros contemporáneos, la música refleja la diversidad y la creatividad de las sociedades en todo el mundo. Entre los muchos aspectos que definen una pieza musical, el ritmo es uno de los más fundamentales. El tempo, o la velocidad a la que se reproduce una composición, es un elemento esencial que influye en la experiencia auditiva y emocional del oyente.

En este contexto, el análisis del tempo de una canción, expresado comúnmente como el número de pulsaciones por minuto (BPM, por sus siglas en inglés), es de gran interés tanto para los músicos como para los investigadores. Los BPM no solo son importantes para los músicos que buscan crear o interpretar música con un ritmo específico, sino también para los desarrolladores de tecnología de audio y aplicaciones de música, que pueden utilizar esta información para mejorar la experiencia del usuario.

En este documento, se presenta un estudio sobre la predicción de BPM de canciones utilizando técnicas de aprendizaje automático. Se explorarán diferentes enfoques para predecir el tempo de una canción, centrándose en tres géneros musicales distintos: trap, rock y bachata. Este estudio se realizará mediante el desarrollo de un programa en Python utilizando bibliotecas como TensorFlow, Librosa, Keras y Tkinter, que permitirá a los usuarios predecir el BPM de una canción según su género musical.

## 🎯 Objetivo
El objetivo principal de este proyecto es desarrollar un programa de predicción de BPM de canciones que sea capaz de:

1.Recopilar datos de audio de diferentes géneros musicales, incluyendo trap, rock y bachata.

2.Extraer características relevantes de las canciones que puedan influir en el tempo, como el ritmo, la estructura de los acordes y la dinámica.

3.Entrenar modelos de aprendizaje automático utilizando TensorFlow y Keras para predecir el BPM de una canción basándose en estas características.

4.Desarrollar una interfaz gráfica de usuario (GUI) utilizando Tkinter que permita a los usuarios seleccionar el género de la canción y obtener una predicción del BPM.
## 📚 Marco Teórico
El marco teórico de este proyecto se basa en varios conceptos fundamentales relacionados con el análisis de audio, el procesamiento de señales digitales y el aprendizaje automático aplicado a la música. Algunos de los conceptos clave incluyen:
### Extracción de características de audio:
Este proceso implica la identificación y extracción de características relevantes de una señal de audio, como el ritmo, la frecuencia y la amplitud. En este proyecto, se utilizará la biblioteca Librosa para extraer características de audio específicas de cada género musical.
### Aprendizaje automático:
El aprendizaje automático es una rama de la inteligencia artificial que se centra en el desarrollo de algoritmos y modelos que permiten a las computadoras aprender patrones a partir de datos y realizar tareas específicas sin ser programadas explícitamente. Se emplearán técnicas de aprendizaje supervisado para entrenar modelos capaces de predecir el BPM de una canción dado su género musical.
### Redes Neuronales Artificiales (ANN)
Las redes neuronales artificiales son modelos computacionales inspirados en el funcionamiento del cerebro humano. En este proyecto, se utilizarán ANN para desarrollar modelos de predicción de BPM utilizando la biblioteca Keras, que es una interfaz de alto nivel para construir y entrenar modelos de aprendizaje profundo.
### Interfaz gráfica de usuario (GUI):
 Una GUI proporciona una interfaz visual que permite a los usuarios interactuar con un programa de manera intuitiva. Se implementará una GUI utilizando Tkinter, una biblioteca estándar de Python para la creación de interfaces gráficas.

Al combinar estos conceptos teóricos con la implementación práctica a través del desarrollo de software, se espera lograr el objetivo de este proyecto: crear un programa funcional y eficaz para predecir el BPM de una canción según su género musical.
### Código Fuente y Procedimientos de Instalación

#### Pre-requisitos
Asegúrate de tener Python 3.8 o superior instalado en tu sistema. Además, necesitarás pip para instalar las librerías.

#### Instalación de Librerías
Para instalar las librerías necesarias, ejecuta el siguiente comando en tu terminal:

```bash
pip install numpy pandas tensorflow keras nltk spacy librosa tkinter pygames customtkinter
```

#### Ejemplo de Código main
```python
import tkinter as tk
from customtkinter import CTkButton, CTkLabel, CTk,CTkFrame
import os
from tkinter import PhotoImage

def open_trap_window():
    os.system("python form_trap.py")

def open_rock_window():
    os.system("python form_rock.py")

def open_bachata_window():
    os.system("python form_bachata.py")

root = CTk() 
root.geometry("500x600+350+20")
root.minsize(480,500)
root.config(bg ='#010101')
root.title("Iniciar Sesion")

frame = CTkFrame(root, fg_color='#010101')
frame.grid(column=0, row = 0, sticky='nsew',padx=50, pady =50)

frame.columnconfigure([0,1], weight=1)
frame.rowconfigure([0,1,2,3,4,5], weight=1)

root.columnconfigure(0, weight=1)
root.rowconfigure(0, weight=1)

logo = PhotoImage(file='images/logo.png') 

# Etiqueta de título con un tamaño de fuente más grande
CTkLabel(frame, image = logo).grid(columnspan=2, row=0)

title_label = CTkLabel(frame, text="WHAT IS THE BPM", fg_color='#21F100', font=("Helvetica", 30))
title_label.grid(columnspan=2, row=1)

# Definir botones para cada género
trap_button =CTkButton(frame,  border_color='#21F100', fg_color='#010101',
	hover_color='#16161a',corner_radius=12,border_width=2,
    text='TRAP', command=open_trap_window)
trap_button.grid(column=0, row=2,padx=4, pady =30, columnspan=2)

rock_button = CTkButton(frame,  border_color='#21F100', fg_color='#010101',
	hover_color='#16161a',corner_radius=12,border_width=2,
    text='ROCK', command=open_rock_window)
rock_button.grid(column=0, row=3,padx=4, pady =30, columnspan=2)

bachata_button = CTkButton(frame,  border_color='#21F100', fg_color='#010101',
	hover_color='#16161a',corner_radius=12,border_width=2,
    text='BACHATA', command=open_bachata_window)
bachata_button.grid(column=0, row=4,padx=4, pady =30, columnspan=2)

root.mainloop()


Este fragmento de código muestra cómo limpiar y tokenizar un texto, eliminando las palabras de parada y filtrando sólo las palabras alfabéticas.

### Primeros Pasos con TensorFlow
TensorFlow es una plataforma integral de código abierto para el aprendizaje automático. Permite a los desarrolladores crear modelos de aprendizaje profundo de manera sencilla.

#### Instalación de TensorFlow
```bash
pip install tensorflow
```

#### Ejemplo de Modelo de Clasificación en librosa
```python
import librosa

def extract_features(audio_path):
    y, sr = librosa.load(audio_path, sr=None)
    tempo = librosa.beat.tempo(y=y, sr=sr)
    return tempo[0]

Este código inicializa un modelo simple de clasificación utilizando TensorFlow y Keras, demostrando cómo construir una red neuronal para tareas de clasificación.


```
#### Ejemplo de Modelo de Clasificación en TensorFlow
```python
import tensorflow as tf

# Construir modelo simple en TensorFlow
model = tf.keras.Sequential([
    Input(shape=(1,)),
    Dense(64, activation='relu'),
    Dense(32, activation='relu'),
    Dense(1)
])

# Compilar el modelo
model.compile(optimizer='adam', loss='mse')

# Entrenar el modelo
model.fit(X_train, y_train, epochs=50, batch_size=1, verbose=2)

```

## 📋 Metodología de trabajo 
- **Recopilación de Datos**: Uso de la libreria librosa para analisis de audio.
- **Preprocesamiento**: Limpieza de datos,carga de datos y entrenamiento.
- **Modelado**: Implementación de una red neuronal con TensorFlow y keras.
con tkinter para una interfaz
- **Evaluación**: Uso de métricas como precisión y recall para evaluar el modelo.

## 🖥️ Modelado o Sistematización
El modelo se entrenó con un dataset de 3 a 5 cancion por genero, ajustando parámetros para optimizar su precisión. Se utilizó una arquitectura de red neuronal de dense de librosa debido a su eficacia en el procesamiento del tempo del audio.

## 📊 Conclusiones
A lo largo de este estudio, se pudo observar la importancia del análisis de audio y el procesamiento de señales digitales en la música, así como el potencial del aprendizaje automático para resolver problemas en este campo. Si bien el programa desarrollado en este proyecto se centró en la predicción de BPM para tres géneros musicales específicos, su estructura modular y flexible permite su adaptación para trabajar con una variedad más amplia de géneros y estilos musicales.
## 📚 Bibliografía
-Ellis, D. P. W. (2007). Beat tracking by dynamic programming. Journal of New Music Research, 36(1), 51–60.
Gouyon, F., Herrera, P., & Cano, P. (2006). Pulse-dependent analysis of percussive music. IEEE Transactions on Audio, Speech, and Language Processing, 14(1), 50–57.
Librosa: Audio and Music Signal Analysis in Python. (s.f.). Recuperado de https://librosa.org/
Python Software Foundation. (s.f.). Python. Recuperado de https://www.python.org/
Estas referencias proporcionan una base s

## 📁 Anexos
- Código Fuente: [GitHub](https://github.com/elbrandy-crow/proyecto-ia)


