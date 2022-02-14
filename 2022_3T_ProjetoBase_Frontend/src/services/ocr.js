import axios from 'axios';

export const LerConteudoDaImagem = async (formData) => {

    let resultado;

    await axios({
        method: "POST",
        url: "https://ocr-eqp-zeck.cognitiveservices.azure.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest",
        data: formData,
        headers: {
            "Content-Type": "multipart/form-data",
            "Ocp-Apim-Subscription-Key": "d89229c89c7b4c038b4df8465b52a457"
        }
    })
    .then(response => {
        // console.log(response);
        resultado = FiltrarOBJ(response.data);
    })
    .catch(erro => console.log(erro))


    return resultado;
}

export const FiltrarOBJ = (obj) => {

    let resultado;

    obj.regions.forEach(region => {
        region.lines.forEach(line =>{
            line.words.forEach(word => {
                if (word.text[0] === '1' && word.text[1] === '2' ){
                    resultado = word.text;
                }
            });
        });
    });

    return resultado;
}