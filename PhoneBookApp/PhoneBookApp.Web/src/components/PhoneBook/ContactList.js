import React from 'react';

function ContactList(props) {

    function handleContactSelect(contact) {
        props.onSelect(contact);
    }

    function handleDelete(id) {
        props.onDelete(id);
    }

    return (
        <ul className="list-group">
            {props.contacts.map(contact =>
                <li key={contact.id} className="list-group-item d-flex justify-content-between">
                    <div className="p-2 pe-auto">
                        <h3>
                            <button className="btn btn-link fs-2 pe-auto" onClick={() => handleContactSelect(contact)}>
                            {contact.firstName} {contact.lastName}
                            </button>
                        </h3>
                        <div className="text-secondary fs-4">
                            <span className="icon-phone"></span>{contact.phoneNumber}
                        </div>
                    </div>
                    <div className="p-3">
                        <button className="btn btn-lg btn-danger" onClick={() => handleDelete(contact.id)}>
                            <span className="icon-trash"></span>
                        </button>
                    </div>
                </li>
            )}
        </ul>        
    );

} export default ContactList