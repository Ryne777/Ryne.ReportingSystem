import { AxiosResponse } from 'axios';
import React, { FC, useState } from 'react'
import { Button, Modal, Form } from 'react-bootstrap';
import { IEngineerCreate } from '../types/engineerType';
import { IOrganizationCreate } from '../types/organizationType';
import { ITypeOfDefectoscopeCreate } from '../types/typeOfDefectoscope';

type SimpleCreate = (IEngineerCreate | IOrganizationCreate | ITypeOfDefectoscopeCreate)
type ICreateSimleModalProps<SimpleCreate> = {
  service: (t: SimpleCreate) => Promise<AxiosResponse<SimpleCreate, any>>
  title: string
}

function CreateSimleModal<T extends SimpleCreate>({ service, title }: ICreateSimleModalProps<T>) {
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
      service(data)
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
          <Button variant="primary" onClick={() => {
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