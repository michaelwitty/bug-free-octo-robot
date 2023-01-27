import React, { useState } from 'react';


function ContactEdit(props)
{
	const [contact, setContact] = useState(props.contact);
	const [validationErrors, setValidationErrors] = useState({});

	function handleSubmit(event) {
		event.preventDefault();

		if (handleValidation()) {
			props.onSubmit(contact);
		}
	}

	function handleValidation() {

		let validationErrors = {};
		let isValid = true;
		if (!contact.firstName) {
			validationErrors.firstName = 'First Name Required';
			isValid = false;
		}
		if (!contact.lastName) {
			validationErrors.lastName = 'Last Name Required';
			isValid = false;
		}
		if (!contact.phoneNumber) {
			validationErrors.phoneNumber = 'Phone Number Required';
			isValid = false;
		}

		setValidationErrors(validationErrors);

		return isValid;
	}

	function handleCancelClick() {
		props.onCancel();
	}

	function handleChange(field, e)
	{
		let updatedContact = { ...contact };
		updatedContact[field] = e.target.value;
		setContact(updatedContact);
	}

	return (
		<form onSubmit={handleSubmit}>
			<h3 className="modal-title">Edit Contact</h3>
			<div className="mb-3">
				<label htmlFor="firstName" className="control-label">First Name</label>
				<input type="text" id="firstName" onChange={(e) => handleChange('firstName', e)} value={contact.firstName} className={`mb-2 form-control form-control-lg${validationErrors['firstName'] && ' is-invalid'}`}></input>
			</div>
			<div className="mb-3">
				<label htmlFor="lastName" className="control-label">Last Name</label>
				<input type="text" id="lastName" onChange={(e) => handleChange('lastName', e)} value={contact.lastName} className={`mb-2 form-control form-control-lg${validationErrors['lastName'] && ' is-invalid'}`}></input>
			</div>
			<div className="mb-3">
				<label htmlFor="phoneNumber" className="control-label">Phone Number</label>
				<input type="text" id="phoneNumber" onChange={(e) => handleChange('phoneNumber', e)} value={contact.phoneNumber} className={`mb-2 form-control form-control-lg${validationErrors['phoneNumber'] && ' is-invalid'}`}></input>
			</div>
			<button type="submit" className="btn btn-lg btn-primary me-3">Save</button>
			<button type="button" onClick={handleCancelClick} className="btn btn-lg btn-danger">Cancel</button>
		</form>
	);

} export default ContactEdit