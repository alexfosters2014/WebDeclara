  window.capturarImagen = (inputFile) => {
    return new Promise(resolve => {
        if (inputFile.files.length === 0) {
            resolve(null);
            return;
        }

        const file = inputFile.files[0];
        const reader = new FileReader();

        reader.onloadend = () => {
            resolve(reader.result);
        };

        reader.readAsDataURL(file);
    });
};