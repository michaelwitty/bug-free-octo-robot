import React, { useState, useEffect } from 'react';
import ContactEdit from '../components/PhoneBook/ContactEdit';
import ContactList from '../components/PhoneBook/ContactList';
import ContactSearch from '../components/PhoneBook/ContactSearch';

function PhoneBook() {

    const LoadingStates = {
        Loading: "Loading",
        Error: "Error",
        Loaded: "Loaded"
    }

    const [loadingState, setLoadingState] = useState(LoadingStates.Loading);
    const [showContactForm, setShowContactForm] = useState(false);
    const [selectedContact, setSelectedContact] = useState({});
    const [searchKeyword, setSearchKeyword] = useState();
    const [contacts, setContacts] = useState([]);

    const baseServiceUrl = "http://localhost:5270/api/Contact/";

    useEffect(() => {
        loadContacts();
    }, [searchKeyword]);

    function loadContacts() {
        var url = baseServiceUrl;

        if (searchKeyword)
            url = url + '?keyword=' + searchKeyword;

        fetch(url, {
            method: "GET"
        }).then(response => {
            if (!response.ok) {
                throw `Error : ${response.status} ${response.statusText} ${response.json}`;
            }
            return response.json()
        })
        .then(json => {
            setContacts(json.items);
            setLoadingState(LoadingStates.Loaded);
        }).catch(err => {
            setLoadingState(LoadingStates.Error);
        });
    }
   
    function handleAddContact() {
        setSelectedContact({ firstName: '', lastName: '', phoneNumber: '' });
        setShowContactForm(true);
    }

    function handleContactSearch(keyword) {
        setSearchKeyword(keyword);
    }

    function handleContactSelect(contact) {

        setSelectedContact(contact)
        setShowContactForm(true);
    }

    function handleContactDelete(id) {
        var url = baseServiceUrl + id;
        fetch(url, {
            method: "DELETE"
        }).then(response => {
            if (!response.ok) {
                throw `Error : ${response.status} ${response.statusText} ${response.json}`;
            }
            loadContacts();
        })
        .catch(err => {
            
        });
    }

    function handleContactFormSubmit(contact) {
        var url = baseServiceUrl;

        if (contact.id)
            url = url + contact.id;

        fetch(url, {
            method: contact.id ? "PUT" : "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(contact)
        }).then(response => {
            if (!response.ok) {
                throw `Error : ${response.status} ${response.statusText} ${response.json}`;
            }

            loadContacts();
            setShowContactForm(false);
        })
        .catch(err => {

        });
    }

    function handleContactFormCancel(id) {
        setShowContactForm(false);
    }

    return (
        <>
        <div className="row mb-2">
            <h1 className="col-6">Contacts</h1>
                <div className="col-6">
                <button className="btn btn-lg btn-primary float-end" onClick={handleAddContact}>+ Add Contact</button>
            </div>
            </div>
        <ContactSearch onChange={(keyword) => handleContactSearch(keyword)} />
            <div className="row mb-2">
                {loadingState === LoadingStates.Loaded &&
                    <ContactList contacts={contacts} onSelect={(contact) => handleContactSelect(contact)} onDelete={(id) => handleContactDelete(id)} />
                }
                {loadingState === LoadingStates.Loading &&
                    <div className="text-center">
                        <div className="spinner-border" role="status">
                            <span className="visually-hidden">Loading...</span>
                        </div>
                    </div>
                }
                {loadingState === LoadingStates.Error &&
                    <p className="text-danger text-center">Something went wrong could not connect to server</p>
                }
                {showContactForm &&
                    <div className="d-flex modal-backdrop">
                    <div className="modal d-block">
                        <div className="modal-dialog">
                            <div className="modal-content">
                                <div className="modal-body">
                                    <ContactEdit contact={selectedContact} onCancel={handleContactFormCancel} onSubmit={(contact) => handleContactFormSubmit(contact)} />
                                </div>
                            </div>
                        </div>
                        </div>
                    </div>
                }
        </div>
        </>
    );

} export default PhoneBook