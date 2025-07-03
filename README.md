# 🎥 FaceRec-AWS Client (.NET Framework)
Este es un cliente de ejemplo en Windows Forms (.NET Framework) para interactuar con el proyecto FaceRec-AWS Web API, el cual realiza reconocimiento facial usando la cámara del sistema, detección con OpenCV y comparación con AWS Rekognition. Las visitas se almacenan localmente en un archivo visits.json.

---
🧠 ¿Cómo funciona?
- Este cliente incluye una interfaz grafica con tres botones:
    - *Iniciar*: Llama a la API para capturar la imagen de la camara, detectar el rostro, compararlo en AWS Rekognition y registrar la visita.
    - *Terminar*: Oculata los btones y vuelve al estado inicial.
    - *Cancelar*: Elimina la ultima visita registrada, en cado de que el usuario reconocido no haya terminado el proceso.
 
  ---
# 🧩 Estructura
El proyecto incluye:
  - *FaceRecogntionService.cs*: clase que contiene fucniones para llamar a las reutas dde la API (check-and-register, delete-last-visit).
  - *FaceModels.cs*: Clases modelo (FaceCheckResult, FaceVisit, DeleteVisitResult) que representan las respuestas que se reciben de la API.
  - *Form1.cs*: La vista ejemplo de Windows Forms con la logica de los botones y la interaccion con el servicio.

  ---
  
# 🚀 Requisitos
- Tener corriendo el backend de FaceRec-AWS localmente
- Tener .NET Framework instalado (recomendando 4.7.2 o superiror, de preferencia 4.8.1)
- Visual Studio para compilar el proyecto de cliente.

-----
# ⚙️ Cómo usar

1. Clona este repositorio y abre el proyecto en Visual Studio.
2. Verifica que el backend (repositorio FaceRec-AWS) este corriendo (por ejemplo:http://localhost:5116).
3. Abre Form1.cs y ejecuta la aplicacion.
4. Haz clic en Iniciar para reconocer y registrar.
     - Si ya ha visitado en las ultimas 24h, se mostrara un mensaje y no podra continuar.
     - Si no ha visitado, se mostraran los botones Terminar y Cancelar.
5. Si el usuario cancela, se eliminara el ultimo registro de visita (rollback).
6. Si termina, vuelve a la pantalla inicial para el siguiente usuario.

---
# 🔗 API Referencia
Este cliente utiliza las siguientes rutas del backend:
- POST /api/FaceRecognition/check-and-register:Captura, detecta, compara y registra la visita.
- DELETE /api/FaceRecognition/delete-last-visit: Eliminar el ultimo iregistro del archivo visits.json.
---
# 📸 Ejemplo de uso
1. Usuario hace clic en Iniciar:
   - Se realiza reconocimiento con la camara y AWS Rekognition.
   - Si ya visito en las ultimas 24h: mensaje de denegacion.
   - Si no: se registra la visita y se muestran botones.
3. Usuario hace clic en:
     - *Terminar*: vuelve al inicio.
     - *Cancelar*: borra la visita recien registrada.

  
  
