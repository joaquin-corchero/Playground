function ExpenseItem(expenseId, name, description, ammount) {
    this.ExpenseId = expenseId;
    this.Name = name;
    this.Description = description;
    this.Ammount = ammount;
    this.CreationDate = Date.now;
    this.ModificationDate = Date.now;

    this.isValid = true;
    this.nameError = "";
    this.descriptionError = "";
    this.ammountError = "";
    this.isNameValid = true;
    this.isDescriptionValid = true;
    this.isAmmountValid = true;

    this.validate = function () {
        this.isValid = true;
        this.validateName();
        this.validateDescription();
        this.validateAmmount();
    };

    this.validateName = function () {
        this.nameError = "";
        this.isNameValid = (new stringRangeValidator(4, 20)).isValid(this.Name);

        if(this.isNameValid)
            return;

        this.nameError = "The name must be between 4 and 20 characters";
        this.isValid = false;
    };


    this.validateDescription = function () {
        this.descriptionError = "";
        this.isDescriptionValid = (new stringRangeValidator(10, 50)).isValid(this.Description);
        if(this.isDescriptionValid)
            return;

        this.descriptionError = "The description must be between 10 and 50 characters";
        this.isDescriptionValid = false;
        this.isValid = false;
    };

    this.validateAmmount = function () {
        this.ammountError = "";
        this.isAmmountValid = this.Ammount > 0 && this.Ammount < 10000;
        if(this.isAmmountValid)
            return;

        this.ammountError = "The ammount must be between 0 and 10000";
        this.isAmmountValid = false;
        this.isValid = false;
    };
}

ExpenseItem.prototype.isReasonable = function()
{
    return this.Ammount <= 100;
}

function stringRangeValidator(minLength, maxLength) {
    this.minLength = minLength;
    this.maxLength = maxLength;

    this.isValid = function (value) {
        return (
            value != null && 
            value.length >= minLength && 
            value.length <= maxLength
            );
    };
};