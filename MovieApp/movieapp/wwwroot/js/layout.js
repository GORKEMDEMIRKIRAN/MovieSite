


function UI()
{
    this.cards=document.querySelectorAll("#cards .card");
    this.paginations=document.querySelectorAll(".pagination .page-link");
    this.categories=document.querySelectorAll(".sectionOne .btn");
    this.DetailButtons=document.querySelectorAll("#watchButtons .btn");
}


document.addEventListener("DOMContentLoaded",function(){
    const ui=new UI();
    //console.log(ui.cards);
    for(let item of ui.cards){
        item.addEventListener("mouseenter",mouseOver);
        item.addEventListener("mouseleave",mouseLeave);
    };
    for(let item of ui.paginations)
    {
        item.addEventListener("mouseenter",mousebtnOver);
        item.addEventListener("mouseleave",mousebtnLeave);
    }
    for(let item of ui.categories)
    {
        item.addEventListener("mouseenter",mousebtnCategoryOver);
        item.addEventListener("mouseleave",mousebtnCategoryLeave);
    }
    for(let item of ui.DetailButtons){
        item.addEventListener("mouseenter",mousebtnDetailsOver);
        item.addEventListener("mouseleave",mousebtnDetailsLeave);
    }

});


//===================================
function mouseOver(e){
    e.preventDefault();
    const element=e.target;
    element.classList.add("f1");

}
function mouseLeave(e){
    e.preventDefault();
    const element=e.target;
    element.classList.remove("f1");
}
//===================================
function mousebtnOver(e){
    e.preventDefault();
    const element=e.target;
    element.classList.add("f2");
    element.classList.add("bg-warning");
}
function mousebtnLeave(e){
    e.preventDefault();
    const element=e.target;
    element.classList.remove("f2");
    element.classList.remove("bg-warning");
}
//===================================
function mousebtnCategoryOver(e){
    e.preventDefault();
    const element=e.target;
    element.classList.add("f3");

}
function mousebtnCategoryLeave(e){
    e.preventDefault();
    const element=e.target;
    element.classList.remove("f3");
}
//===================================
function mousebtnDetailsOver(e){
    e.preventDefault();
    const element=e.target;
    element.classList.add("f4");

}
function mousebtnDetailsLeave(e){
    e.preventDefault();
    const element=e.target;
    element.classList.remove("f4");
}
//===================================