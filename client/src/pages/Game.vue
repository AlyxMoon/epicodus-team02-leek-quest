<template>  
  <div class="grid">
    <div 
      class="cell" 
      v-for="i of (boardSize * boardSize)"
      :key="i"
    >
      {{ i }}
    </div>
  </div>
</template>

<script>
export default {
  name: 'GamePage',
  data: () => ({
    boardSize: 20,
  }),
}
</script>

<style scoped>

.grid {
  --cell-size: 30px;

  display: grid;
  grid-gap: 1px;

  background-color: black;
  border: 1px solid black;

  margin: 0 auto;
  max-width: fit-content;

  grid-template-columns: repeat(20, var(--cell-size));
  grid-auto-rows: var(--cell-size);
}

.cell {
  background-color: white;
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>