$(() => {

    let counter = 1;
    $("#add-button").on('click', function () {
        $("#span").append(`<div class='row col-md-12 mt-3' id='${counter}'> 
                            <input type = 'text' name = 'people[${counter}].firstName' placeholder = 'first name' class= 'form-control col-md-4' /> 
                            <input type='text' name='people[${counter}].lastName' placeholder='last name' class='form-control col-md-4' /> 
                            <input type='text' name='people[${counter}].age' placeholder='age' class='form-control col-md-4' /> </div >`);
        counter++;
    });
});