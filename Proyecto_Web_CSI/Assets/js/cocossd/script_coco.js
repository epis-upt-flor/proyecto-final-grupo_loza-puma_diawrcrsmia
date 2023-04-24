const video = document.getElementById('webcam');
const liveView = document.getElementById('liveView');
const demosSection = document.getElementById('demos');

const enableWebcamButton = document.getElementById('webcamButton');


function getUserMediaSupported() {
    return !!(navigator.mediaDevices && navigator.mediaDevices.getUserMedia);
}


if (getUserMediaSupported()) {
    enableWebcamButton.addEventListener('click', enableCam);
} else {
    console.warn('getUserMedia() incopatibilidad  con la camara');
}


function enableCam(event) {
    
    if (!model) {
        return;
    }


    event.target.classList.add('removed');

 
    const constraints = {
        video: true
    };


    navigator.mediaDevices.getUserMedia(constraints).then(function (stream) {
        video.srcObject = stream;
        video.addEventListener('loadeddata', predictWebcam);
    });
}


var model = true;
demosSection.classList.remove('invisible');



var model = undefined;


cocoSsd.load().then(function (loadedModel) {
    model = loadedModel;
    
    demosSection.classList.remove('invisible');
});

var children = [];
var valor = 0;
var vista = 0;

function predictWebcam() {
    
    model.detect(video).then(function (predictions) {

        for (let i = 0; i < children.length; i++) {
            liveView.removeChild(children[i]);
        }
        children.splice(0);


        for (let n = 0; n < predictions.length; n++) {
            
            if (predictions[n].score > 0.66) {
                const p = document.createElement('p');

                if (predictions[n].class == "bottle") {

                    p.innerText = 'Botella de Plastico' + ' - con '
                        + Math.round(parseFloat(predictions[n].score) * 100)
                        + '% de confinza';
                    p.style = 'margin-left: ' + predictions[n].bbox[0] + 'px; margin-top: '
                        + (predictions[n].bbox[1] - 10) + 'px; width: '
                        + (predictions[n].bbox[2] - 10) + 'px; top: 0; left: 0;';

                    const highlighter = document.createElement('div');
                    highlighter.setAttribute('class', 'highlighter');
                    highlighter.style = 'left: ' + predictions[n].bbox[0] + 'px; top: '
                        + predictions[n].bbox[1] + 'px; width: '
                        + predictions[n].bbox[2] + 'px; height: '
                        + predictions[n].bbox[3] + 'px;';

                    liveView.appendChild(highlighter);
                    liveView.appendChild(p);
                    children.push(highlighter);
                    children.push(p);

                    if(Math.round(parseFloat(predictions[n].score) * 100) > 90){
                        
                        if(predictions[n].class =! "bottle"){
                                                    
                           vista = 1; 
                        }else{
                                                     
                           vista = 0; 

                        }
                        if(vista = 1){
                            valor++;
                            document.getElementById("contador").innerHTML = "El Contador de botellas: " + valor;//Asignar valor
                        }
                        
                        
                    }
                    
                    
                    
                }
            }
        }


        window.requestAnimationFrame(predictWebcam);
    });
}



