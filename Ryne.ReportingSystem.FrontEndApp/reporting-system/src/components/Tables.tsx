import { Table } from "react-bootstrap"
import Head from "./Head";
import Row from "./Row";

interface ITablesProps<ObjectType> {
  objects: ObjectType[];
  properties: {
    key: keyof ObjectType,
    title: string,
  }[];
}


function Tables<ObjectType extends { id: string }>(
  { objects, properties }: ITablesProps<ObjectType>,
) {
  return (
    <Table striped bordered hover size="sm" className="text-center align-middle">
      <Head
        properties={properties}
      />
      <tbody>
        {
          objects.map((object, i: number) => (
            <Row
              key={object.id}
              object={object}
              properties={properties}
              counter={i + 1}
            />
          ))
        }
      </tbody>
    </Table>
  );
}

export default Tables;
