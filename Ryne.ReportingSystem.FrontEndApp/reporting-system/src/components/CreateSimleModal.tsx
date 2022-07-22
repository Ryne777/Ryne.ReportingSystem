import { AsyncThunk } from '@reduxjs/toolkit/dist/createAsyncThunk';
import React, { useState } from 'react'
import { Button, Modal, Form } from 'react-bootstrap';
import { useAppDispatch } from '../hooks/redux';
import { IEngineerCreate } from '../types/engineerType';
import { IOrganizationCreate } from '../types/organizationType';
import { ITypeOfDefectoscopeCreate } from '../types/typeOfDefectoscope';

type SimpleCreate = (IEngineerCreate | IOrganizationCreate | ITypeOfDefectoscopeCreate)
type ICreateSimleModalProps<SimpleCreate> = {
  reducer: AsyncThunk<any, SimpleCreate, { rejectValue: any }>
  title: string
}

function CreateSimleModal<T extends SimpleCreate>({ reducer, title, }: ICreateSimleModalProps<T>) {
  const dispatch = useAppDispatch()
  const [show, setShow] = useState(false)
  const [value, setValue] = useState("")

  const handleClose = () => setShow(false)
  const handleShow = () => setShow(true)
  const inputHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    const enteredName = event.target.value;
    setValue(enteredName);
  }

  const Create = (data: T,) => {
    try {
      dispatch(reducer(data))
    }
    catch (err) {
      alert(err)
    }

  }

  return (
    <>
      <Button variant="success" className="me-1" onClick={handleShow}>
        <i className="bi bi-plus-lg"></i>
      </Button>

      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>{title}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group className="mb-3" controlId="Name">
              <Form.Label>Имя</Form.Label>
              <Form.Control
                type="text"
                placeholder="Имя"
                autoFocus
                value={value}
                onChange={inputHandler}
              />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            onClick={handleClose}

          >
            Close
          </Button>
          <Button variant="primary"
            onClick={() => {
              Create({ name: value } as T)
              handleClose()
            }}>
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  )
}

export default CreateSimleModal