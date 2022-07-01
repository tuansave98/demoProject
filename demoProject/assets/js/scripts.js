function edit(clicked_id)
{ 
    loadDataToForm (clicked_id)
}


function deleteCustomer(id)
{
    var id = parseInt(id);
    $.ajax({
        url: '/home/deleteCustommer',
        dataType: 'json',       
        data: { id: id },
        type:'POST',
        success: function (response) {
            if(response.status==true)
            {
                $('#row_' + id).remove();
            }
        }
    });

}

function loadDataToForm (id)
{ 

    $('.btn.btn-primary.update').css("display","block");
    var dataName= $('#name_'+id).html();
    var dataAddress = $('#address_'+id).html();
    var dataPhone = $('#phone_'+id).html();
    var dataEmail = $('#email_'+id).html();
    var dataDob= $('#dob_'+id).html();

    $('#txtName').val(dataName);
    $('#txtAddress').val(dataAddress);
    $('#txtPhone').val(dataPhone);
    $('#txtEmail').val(dataEmail);
    $('#txtDob').val(dataDob);
    $('.btn.btn-primary').attr('id',id);

}


function updateCustomerInfor(id)
{
    var newName = $('#txtName').val();
    var newAddress = $('#txtAddress').val();
    var newPhone = $('#txtPhone').val();
    var newEmail = $('#txtEmail').val();
    var newDob = $('#txtDob').val();
    $.ajax(
        {
            url:'/home/editCustommer',
            dataType:'json',
            data:{id:id,name:newName,address:newAddress,phone:newPhone,email:newEmail,dob:newDob},
            
            type:'POST',
            success:function(response)
            {
                var rs = response.status;
                if (rs == true) {
                    updateTable(id, newName, newAddress, newPhone, newEmail, newDob);
                
                }
                else {
                    alert("loi");
                }
            }
        }
    )
}


function addCustomer()
{
    $('.form-horizontal').css("display","flex");
    var Name = $('#txtName').val();
    var Address = $('#txtAddress').val();
    var Phone = $('#txtPhone').val();
    var Email = $('#txtEmail').val();
    var Dob = $('#txtDob').val();
    $.ajax({ 
        url: '/home/addCustomer',
        type:'POST',
        dataType:'json',
        data:{name: Name,address: Address,phone: Phone,email: Email,dob: Dob},
        success:function(response)
        {
            var rs= response.status;
 
                $('#tableCustomer').append("<tr id=row_"+rs+"> <td id='name_"+rs+"'>"+Name+
                "</td> <td id='address_"+rs+"'>"+Address+
                "</td> <td id='phone_"+rs+"'>"+Phone+
                "</td> <td id='email_"+rs+"'>"+Email+
                "</td> <td id='dob_"+rs+"'>"+Dob+"</td> <td><button class=\"btn btn-warning\" onclick="+'edit('+rs+
                ")>Sửa</button> <button class=\"btn btn-danger\" onclick=\"deleteCustomer("+rs+")\">Xoá</button>    </td> </tr>")
        }
    })


}




// refresh data in customer table
function updateTable(id,name,address,phone,email,dob)
{
    $('#name_'+id).html(name);
    $('#address_' + id).html(address);
    $('#phone_' + id).html(phone);
    $('#email_' + id).html(email);
    $('#dob_' + id).html(dob);
}

