import React from 'react';

function ContactSearch(props) {

    function handleSearchTermChange(e) {

        props.onChange(e.target.value);
    }

    return (
        <form className="my-3">
            <div className="input-group">
                <span className="input-group-text">
                    <span className="icon-search fs-5"></span>
                </span>
                <input type="text" onChange={handleSearchTermChange} className="form-control form-control-lg icon-search" placeholder="Search for contact by last name..."></input>
            </div>
        </form>
    );

} export default ContactSearch