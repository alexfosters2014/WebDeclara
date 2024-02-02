window.LeerVoz = () => {
    return new Promise((resolve, reject) => {
        let textoReconocido = '';

        
        // Verificar si el navegador admite el reconocimiento de voz
        if ('SpeechRecognition' in window || 'webkitSpeechRecognition' in window) {
            // Crear una instancia de SpeechRecognition
            const recognition = new (window.SpeechRecognition || window.webkitSpeechRecognition)();
          

            // Establecer el idioma a español
            recognition.lang = 'es-ES';

   
           

            // Definir la función que se ejecutará cuando se detecte voz
            recognition.onresult = (event) => {
                textoReconocido = event.results[0][0].transcript;

                // Si se detecta la palabra "ok", detener el reconocimiento de voz y resolver la promesa con el texto
                if (textoReconocido.toLowerCase().includes('okay')) {
                    recognition.continuous = false; 
                    recognition.stop();
                    resolve(textoReconocido);
                }
            };

            // Manejar errores
            recognition.onerror = (event) => {
                reject(event.error);
            };

            // Manejar la finalización del reconocimiento
            recognition.onend = () => {
                resolve(textoReconocido);
            };

            // Iniciar el reconocimiento automáticamente al cargar la página
            recognition.start();
        } else {
            reject('No se admite el reconocimiento de voz en este navegador.');
        }
    });
};