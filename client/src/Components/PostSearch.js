import React, { useContext, useState } from "react";
import { PostContext } from "../Providers/PostProvider";
import { Form, FormGroup, Label, Input, Button } from "reactstrap";

const PostSearch = () => {

    const [search, setSearch] = useState("")
    const { getAllSearch } = useContext(PostContext);

    const handleNewSearch = (event) => {
        event.preventDefault();
        getAllSearch(search);

    }
    const handleFieldChange = (event) => {
        const stateToChange = event.target.value;
        setSearch(stateToChange);
    }

    return (
        <Form className="postForm" onSubmit={handleNewSearch}>
            <FormGroup>
                <Label className="postTitleLabel">Search bar</Label>
                <Input
                    className="newPost"
                    onChange={handleFieldChange}
                    type="text"
                    id="search"
                    placeholder="Enter Title"
                />
            </FormGroup>


            <Button
                className="searchButton"
                onClick={handleNewSearch}
                variant="custom"
                type="submit"
            >
                Search
        </Button>
        </Form>
    )
}
export default PostSearch


