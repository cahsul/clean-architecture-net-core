export function Gambar() {

    var width = window.innerWidth;
    var height = window.innerHeight;

    var stage = new Konva.Stage({
        container: 'containerKonva',
        width: width,
        height: height,
    });

    var layer = new Konva.Layer();
    var rectX = stage.width() / 2 - 50;
    var rectY = stage.height() / 2 - 25;

    var box = new Konva.Rect({
        x: rectX,
        y: rectY,
        width: 100,
        height: 50,
        fill: '#00D2FF',
        stroke: 'black',
        strokeWidth: 4,
        draggable: true,
    });

    var simpleText = new Konva.Text({
        text: 'Simple Text',
        fontSize: 30,
        fontFamily: 'Calibri',
        fill: 'green',
        draggable: true,
    });
    layer.add(simpleText);
    var MIN_WIDTH = 20;
    var tr = new Konva.Transformer({
        nodes: [simpleText],
        padding: 5,
        // enable only side anchors
        enabledAnchors: ['middle-left', 'middle-right'],
        // limit transformer size
        boundBoxFunc: (oldBox, newBox) => {
            if (newBox.width < MIN_WIDTH) {
                return oldBox;
            }
            return newBox;
        },
    });
    layer.add(tr);
    simpleText.on('transform', () => {
        // with enabled anchors we can only change scaleX
        // so we don't need to reset height
        // just width
        simpleText.setAttrs({
            width: Math.max(simpleText.width() * simpleText.scaleX(), MIN_WIDTH),
            scaleX: 1,
            scaleY: 1,
        });
    });



    // add cursor styling
    box.on('mouseover', function () {
        document.body.style.cursor = 'pointer';
    });
    box.on('mouseout', function () {
        document.body.style.cursor = 'default';
    });

    layer.add(box);
    stage.add(layer);

}


var canvas;

export function fabrik() {
    canvas = new fabric.Canvas("c");
    var text = new fabric.Textbox('Hello world From Fabric JS', {
        width: 250,
        cursorColor: "blue",
        top: 10,
        left: 10
    });
    canvas.add(text);

    var img = new fabric.Image.fromURL("assets/images/backgrounds/user_bg4.jpg", function (image) {
        canvas.add(image.set({
            id: 'abc',
            alt: 'xyz',
            width: 250,
            height: 250,
            left: 240,
            top: 50,
        }));
    }, { crossOrigin: 'anonymous'});


    var text2 = new fabric.Textbox('yooo apa kabar', {
        width: 250,
        cursorColor: "red",
        top: 10,
        left: 500
    });
    canvas.add(text2);

    var bola = new fabric.Circle({ radius: 30, fill: '#f55', top: 100, left: 100 });
    canvas.add(bola);

    


}

export function SaveImage() {
    var canvaszzz = document.getElementById("c");

    var json = JSON.stringify(canvas);
    console.log(json);

    var imageqwe = canvaszzz.toDataURL("image/jpg");
   // document.write('<img src="' + imageqwe + '"/>');
    //var img = canvas.toDataURL("image/png");
    window.open("data:application/pdf;base64," + imageqwe);
}