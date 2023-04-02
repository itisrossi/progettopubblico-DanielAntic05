document.addEventListener("DOMContentLoaded", () => {
    const grid = document.querySelector(".grid");
    const width = 8;
    const squares = [];
    let score = 0;

    const candyColors = [
        "red",
        "yellow",
        "orange",
        "purple",
        "green",
        "blue"
    ]

    // Board
    function creatBoard(){
        for (let i = 0; i < width * width; i++) {
            const square = document.createElement("div");

            // making the square draggable
            square.setAttribute("draggable", true);

            // getting the id of each squar (from 0 to 63)
            square.setAttribute("id", i);

            // assaigning a random color to each square
            let randomColor = Math.floor(Math.random() * candyColors.length);
            square.style.backgroundColor = candyColors[randomColor];

            // creating square inside the boards
            grid.appendChild(square);
            squares.push(square);
        }
    }
    creatBoard();

    //  Drag the candies

    // to know the color that is dragged
    let colorBeingDragged;

    // to know the color which will be replaced
    let colorBeingReplaced;

    let squareIdBeingDragged;
    let squareIdBeingReplaced;

    squares.forEach(square => square.addEventListener("dragstart", dragStart));
    squares.forEach(square => square.addEventListener("dragend", dragEnd));
    squares.forEach(square => square.addEventListener("dragover", dragOver));
    squares.forEach(square => square.addEventListener("dragenter", dragEnter));
    squares.forEach(square => square.addEventListener("dragleave", dragLeave));
    squares.forEach(square => square.addEventListener("drop", dragDrop));

    function dragStart(){
        colorBeingDragged = this.style.backgroundColor;
        squareIdBeingDragged = parseInt(this.id);
        // console.log(colorBeingDragged);
        // console.log(this.id, "dragstart");
    }

    function dragOver(e){
        e.preventDefault();
        // console.log(this.id, "dragover");
    }

    function dragEnter(e){
        e.preventDefault();
        // console.log(this.id, "dragenter");
    }

    function dragLeave(){
        // console.log(this.id, "dragleave");
        this.style.backgroundColor = "";

    }

    function dragDrop(){
        // console.log(this.id, "drop");
        colorBeingReplaced = this.style.backgroundColor;
        squareIdBeingReplaced = parseInt(this.id);
        this.style.backgroundColor = colorBeingDragged;
        squares[squareIdBeingDragged].style.backgroundColor = colorBeingReplaced;
    }

    function dragEnd(){
        // console.log(this.id, "dragend");
        
        // valid move
        let validMoves = [
            squareIdBeingDragged - 1, 
            squareIdBeingDragged - width,
            squareIdBeingDragged + 1,
            squareIdBeingDragged + width
        ];
        let validMove = validMoves.includes(squareIdBeingReplaced);

        // they both must be true
        if (squareIdBeingReplaced && validMove) {
            squareIdBeingReplaced = null;
        } else if (squareIdBeingReplaced && !validMove) {
            squares[squareIdBeingReplaced].style.backgroundColor = colorBeingReplaced;
            squares[squareIdBeingDragged].style.backgroundColor = colorBeingDragged;
        } else {
            squares[squareIdBeingDragged].style.backgroundColor = colorBeingDragged;
        }
    }

    // Checking for matches
    // check for row of Three
    function checkRowForThree(){
        for (let i = 0; i < 61; i++) {
            let rowOfThree = [i, i + 1, i + 2];
            let decidedColor = squares[i].style.backgroundColor;
            const isBlank = squares[i].style.backgroundColor === "";

            if (rowOfThree.every(index => squares[index].style.backgroundColor === decidedColor && !isBlank)) {
                score += 3;
                rowOfThree.forEach(index => {
                    squares[index].style.backgroundColor = "";
                });
            }
        }
    }
    checkRowForThree();

    window.setInterval(function() {
        checkRowForThree();
    }, 100);

});